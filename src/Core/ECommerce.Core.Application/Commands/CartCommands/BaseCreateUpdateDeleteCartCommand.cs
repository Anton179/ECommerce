using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess.Entities;
using MediatR;

namespace ECommerce.Core.Application.Commands.CartCommands
{
    public class BaseCreateUpdateDeleteCartCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
