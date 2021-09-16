using System;
using ECommerce.Core.DataAccess.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.Core.DataAccess.Auth;
using ECommerce.Core.DataAccess.Dtos.ShippingDtos;
using ECommerce.Core.DataAccess.Dtos.UserDtos;
using ECommerce.Core.DataAccess.Entities;

namespace ECommerce.Core.DataAccess.Dtos.OrderDtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentType Payment { get; set; }
        public string Address { get; set; }
        public virtual ShippingDto Shipping { get; set; }
        public virtual UserDto User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<OrderProductsDto> OrderProducts { get; set; }
    }
}
