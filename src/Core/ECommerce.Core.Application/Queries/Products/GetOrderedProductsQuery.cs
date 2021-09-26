using System;
using ECommerce.Core.Application.Infrastructure.Dtos.ProductDtos;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;
using MediatR;

namespace ECommerce.Core.Application.Queries.Products
{
    public class GetOrderedProductsQuery : PagedRequest, IRequest<PaginatedResult<ProductForDisplayDto>>
    {
    }
}
