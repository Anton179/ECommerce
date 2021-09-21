using MediatR;
using System;

namespace ECommerce.Core.Application.Commands.ProductCommands
{
    public class DeleteProductCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
