using System;
using ECommerce.Core.Application.Infrastructure.Dtos.ProductDtos;

namespace ECommerce.Core.Application.Infrastructure.Dtos.OrderDtos
{
    public class OrderProductsDto
    {
        public Guid Id { get; set; }
        public virtual ProductForDisplayDto Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
