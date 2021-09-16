using ECommerce.Core.DataAccess.Auth;
using System;
using System.Collections.Generic;
using ECommerce.Core.DataAccess.Enums;

namespace ECommerce.Core.DataAccess.Entities
{
    public class Order : BaseEntity
    {
        public Guid? UserId { get; set; }
        public Guid ShippingId { get; set; }
        public decimal Price { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentType Payment { get; set; }
        public string Address { get; set; }
        public virtual Shipping Shipping { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
