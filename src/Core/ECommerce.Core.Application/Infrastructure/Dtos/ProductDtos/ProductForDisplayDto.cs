using System;

namespace ECommerce.Core.Application.Infrastructure.Dtos.ProductDtos
{
    public class ProductForDisplayDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public double Weight { get; set; }
        public bool InStock { get; set; }
    }
}
