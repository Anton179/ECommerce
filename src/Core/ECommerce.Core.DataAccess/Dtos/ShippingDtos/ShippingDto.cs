using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.DataAccess.Dtos.ShippingDtos
{
    public class ShippingDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Estimated { get; set; }
    }
}
