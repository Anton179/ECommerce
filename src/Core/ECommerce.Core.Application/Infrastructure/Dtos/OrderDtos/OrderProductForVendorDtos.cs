using ECommerce.Core.Application.Infrastructure.Dtos.ProductDtos;
using ECommerce.Core.Application.Infrastructure.Dtos.UserDtos;
using System;
using ECommerce.Core.DataAccess.Enums;

namespace ECommerce.Core.Application.Infrastructure.Dtos.OrderDtos
{
    public class OrderProductForVendorDtos
    {
        public Guid Id { get; set; }
        public virtual ProductForDisplayDto Product { get; set; }
        public virtual UserDto User { get; set; }
        public OrderStatus Status { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
