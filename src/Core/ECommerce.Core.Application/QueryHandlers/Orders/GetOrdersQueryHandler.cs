using ECommerce.Core.Application.Queries.Orders;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess.Dtos.OrderDtos;

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

            var filter = new Filter() {Path = "o => o.UserId.ToString()", Value = userId.ToString()};
            request.PagedRequest.RequestFilters.Filters.Add(filter);

            var result = await _orderRepository.GetPagedData<OrderDto>(request.PagedRequest);

            return result;
        }
    }
}
