using System;
using MediatR;

namespace ECommerce.Core.Application.Commands.CartCommands
{
    public class DeleteAllCartCommand : IRequest<Guid>
    {
    }
}
