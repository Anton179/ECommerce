using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Application.Commands.CartCommands
{
    public class DeleteCartCommand : IRequest<Guid>
    {
        [Required]
        public Guid? ProductId { get; set; }
    }
}
