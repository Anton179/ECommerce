using AutoMapper;
using ECommerce.Core.Application.Queries.Orders;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Dtos.OrderDtos;
using ECommerce.Core.Application.Infrastructure.Exceptions;
using ECommerce.Core.Application.Infrastructure.Interfaces;

namespace ECommerce.Core.Application.QueryHandlers.Orders
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IGenericRepository<Order> orderRepository,
                                     ICurrentUserProvider currentUserProvider, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _currentUserProvider = currentUserProvider;
            _mapper = mapper;
        }
        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

            var userId = _currentUserProvider.GetUserId();

            if (order == null || order.UserId != userId)
            {
                throw new NotFoundException("Order not found!");
            }

            var result = _mapper.Map<OrderDto>(order);

            return result;
        }
    }
}
