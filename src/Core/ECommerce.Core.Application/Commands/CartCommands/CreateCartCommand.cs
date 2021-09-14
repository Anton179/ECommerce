using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ECommerce.Core.Application.Commands.CartCommands
{
    public class CreateCartCommand : IRequest<Guid>
    {
        [Required]
        public Guid? ProductId { get; set; }
        [Required]
        public int? Quantity { get; set; }
    }
}
