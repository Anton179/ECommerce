using MediatR;
using System;
using ECommerce.Core.Application.Infrastructure.Dtos.ProductDtos;

namespace ECommerce.Core.Application.Queries.Products
{
    public class GetProductQuery : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
    }
}
