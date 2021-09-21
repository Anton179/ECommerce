using MediatR;
using System;

namespace ECommerce.Core.Application.Commands.CartCommands
{
    public class CreateCartItemsFromOrderCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
