using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Authorization;
using ECommerce.Core.Application.Infrastructure.Dtos.OrderDtos;
using ECommerce.Core.Application.Infrastructure.Interfaces;
using ECommerce.Core.Application.Queries.Orders;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;
using ECommerce.Core.DataAccess.Models.PagedRequestModels.FilterEnums;

namespace ECommerce.Core.Application.QueryHandlers.Orders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, PaginatedResult<OrderDto>>
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly ICurrentUserProvider _currentUserProvider;

        public GetOrdersQueryHandler(IGenericRepository<Order> orderRepository, ICurrentUserProvider currentUserProvider)
        {
            _orderRepository = orderRepository;
            _currentUserProvider = currentUserProvider;
        }

        public async Task<PaginatedResult<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserProvider.GetUserId();
            var role = _currentUserProvider.GetUserRole();

            if (role == Roles.User)
            {
                var filter = new Filter() { Path = "UserId.ToString()", Value = userId.ToString(), Operator = FilterOperators.Equals };
                request.RequestFilters.Filters.Add(filter);
            }

            var result = await _orderRepository.GetPagedData<OrderDto>(request);

            return result;
        }
    }
}
