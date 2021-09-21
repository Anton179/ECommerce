using ECommerce.Core.Application.Infrastructure.Dtos.OrderDtos;
using ECommerce.Core.Application.Infrastructure.Dtos.ShippingMethodDtos;
using ECommerce.Core.DataAccess.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using ECommerce.Core.DataAccess.Entities;

namespace ECommerce.Core.Application.Commands.OrderCommands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public PaymentType Payment { get; set; }
        public string Address { get; set; }
        public ShippingMethodDto Shipping { get; set; }
        public ICollection<OrderProductsDto> OrderProducts { get; set; }
    }
}
