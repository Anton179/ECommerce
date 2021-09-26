using ECommerce.Core.Application.Infrastructure.Dtos.ProductDtos;
using ECommerce.Core.Application.Queries.Products;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.Application.Infrastructure.Interfaces;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using ECommerce.Core.DataAccess.Models.PagedRequestModels.FilterEnums;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Core.Application.QueryHandlers.Products
{
    public class GetOrderedProductsQueryHandler : IRequestHandler<GetOrderedProductsQuery, PaginatedResult<ProductForDisplayDto>>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly ICurrentUserProvider _currentUserProvider;

        public GetOrderedProductsQueryHandler(IGenericRepository<Product> productRepository,
            IGenericRepository<Order> orderRepository, ICurrentUserProvider currentUserProvider)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _currentUserProvider = currentUserProvider;
        }

        public async Task<PaginatedResult<ProductForDisplayDto>> Handle(GetOrderedProductsQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserProvider.GetUserId();

            var productIds = await _orderRepository.Read()
                .Where(x => x.UserId == userId)
                .SelectMany(order => order.OrderProducts,
                    (order, products) => new
                    {
                        ProductId = products.ProductId.ToString()
                    }).Distinct().Select(x => x.ProductId).ToListAsync(cancellationToken);

            var filters = new List<Filter>
            {
                new Filter() {Path = GetCustomProductsFilterPath(productIds), Operator = FilterOperators.Custom}
            };

            var requestFilters = new RequestFilters() {Filters = filters, LogicalOperator = FilterLogicalOperators.And};

            request.RequestFilters = requestFilters;

            var result = await _productRepository.GetPagedData<ProductForDisplayDto>(request);

            return result;
        }

        private string GetCustomProductsFilterPath(List<string> idList)
        {
            var productsFilter = "(";

            for (int i = 0; i < idList.Count; i++)
            {
                productsFilter += $"Id.ToString().Equals(\"{idList[i]}\")";

                if (i != idList.Count - 1)
                {
                    productsFilter += " Or ";
                }
            }

            return productsFilter + ") ";
        }
    }
}
