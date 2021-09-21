using ECommerce.Core.Application.Infrastructure.Dtos.ProductDtos;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;
using MediatR;

namespace ECommerce.Core.Application.Queries.Products
{
    public class GetAllProductsQuery : IRequest<PaginatedResult<ProductForDisplayDto>>
    {
        public PagedRequest PagedRequest { get; set; }
    }
}
