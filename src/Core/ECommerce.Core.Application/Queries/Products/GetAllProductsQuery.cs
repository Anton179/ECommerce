using ECommerce.Core.DataAccess.Dtos.ProductDtos;
using MediatR;
using System.Collections.Generic;

namespace ECommerce.Core.Application.Queries.Products
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductForDisplayDto>>
    {
    }
}
