using MediatR;
using System;

namespace ECommerce.Core.Application.Commands.CartCommands
{
    public class DeleteCartItemCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
    }
}
