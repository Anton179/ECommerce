using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess.Dtos.ShippingDtos;
using ECommerce.Core.DataAccess.Enums;
using MediatR;

namespace ECommerce.Core.Application.Commands.OrderCommands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public PaymentType Payment { get; set; }
        public string Address { get; set; }
        public ShippingDto Shipping { get; set; }
    }
}
