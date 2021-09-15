using ECommerce.Core.DataAccess.Dtos.ProductDtos;
using MediatR;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;

namespace ECommerce.Core.Application.Queries.Products
{
    public class GetAllProductsQuery : IRequest<PaginatedResult<ProductForDisplayDto>>
    {
        public PagedRequest PagedRequest { get; set; }
    }
}
