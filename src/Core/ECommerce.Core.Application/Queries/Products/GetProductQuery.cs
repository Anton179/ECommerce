using System;
using ECommerce.Core.DataAccess.Dtos.Product;
using MediatR;

namespace ECommerce.Core.Application.Queries.Products
{
    public class GetProductQuery : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
    }
}
