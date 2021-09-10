using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess.Dtos.ShippingDtos;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Enums;
using MediatR;

namespace ECommerce.Core.Application.Commands.OrderCommands
{
    public class BaseCreateUpdateOrderCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public PaymentType Payment { get; set; }
        public OrderStatus Status { get; set; }
        public int Quantity { get; set; }
        public string Address { get; set; }
        public ShippingDto Shipping { get; set; }
    }
}
