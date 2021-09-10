using ECommerce.Core.DataAccess.Enums;
using System.Collections.Generic;

namespace ECommerce.Core.DataAccess.Dtos.OrderDtos
{
    public class OrderDto
    {
        public decimal Price { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentType Payment { get; set; }
        public virtual ICollection<OrderProductsDto> OrderProducts { get; set; }
    }
}
