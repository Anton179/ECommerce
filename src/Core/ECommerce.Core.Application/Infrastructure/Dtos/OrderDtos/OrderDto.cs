using System;
using System.Collections.Generic;
using ECommerce.Core.Application.Infrastructure.Dtos.ShippingMethodDtos;
using ECommerce.Core.Application.Infrastructure.Dtos.UserDtos;
using ECommerce.Core.DataAccess.Enums;

namespace ECommerce.Core.Application.Infrastructure.Dtos.OrderDtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentType Payment { get; set; }
        public string Address { get; set; }
        public Guid ShippingId { get; set; }
        public virtual ShippingMethodDto Shipping { get; set; }
        public virtual UserDto User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<OrderProductsDto> OrderProducts { get; set; }
    }
}
