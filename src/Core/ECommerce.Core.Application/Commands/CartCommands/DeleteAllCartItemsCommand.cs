using MediatR;
using System;

namespace ECommerce.Core.Application.Commands.CartCommands
{
    public class DeleteAllCartItemsCommand : IRequest<Guid>
    {
    }
}
