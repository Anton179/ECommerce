using ECommerce.Core.Application.Infrastructure.Dtos.OrderDtos;
using ECommerce.Core.Application.Infrastructure.Interfaces;
using ECommerce.Core.Application.Queries.Orders;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;
using ECommerce.Core.DataAccess.Models.PagedRequestModels.FilterEnums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Core.Application.QueryHandlers.Orders
{
    public class GetOrderProductsQueryHandler : IRequestHandler<GetOrderProductsQuery, PaginatedResult<OrderProductForVendorDtos>>
    {
        private readonly IGenericRepository<OrderProducts> _orderProductsRepository;
        private readonly ICurrentUserProvider _currentUserProvider;

        public GetOrderProductsQueryHandler(IGenericRepository<OrderProducts> orderProductsRepository, ICurrentUserProvider currentUserProvider)
        {
            _orderProductsRepository = orderProductsRepository;
            _currentUserProvider = currentUserProvider;
        }

        public async Task<PaginatedResult<OrderProductForVendorDtos>> Handle([FromQuery] GetOrderProductsQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserProvider.GetUserId();

            var filter = new Filter() { Path = "Product.OwnerId.ToString()", Value = userId.ToString(), Operator = FilterOperators.Equals };
            request.RequestFilters.Filters.Add(filter);

            var result = await _orderProductsRepository.GetPagedData<OrderProductForVendorDtos>(request);

            return result;
        }
    }
}
