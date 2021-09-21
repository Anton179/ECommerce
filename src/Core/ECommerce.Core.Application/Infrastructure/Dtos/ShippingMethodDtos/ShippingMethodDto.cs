using System;

namespace ECommerce.Core.Application.Infrastructure.Dtos.ShippingMethodDtos
{
    public class ShippingMethodDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Estimated { get; set; }
    }
}
