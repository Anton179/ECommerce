using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Application.Commands.CartCommands
{
    public class CreateCartItemCommand : IRequest<Guid>
    {
        [Required]
        public Guid? ProductId { get; set; }
        [Required]
        public int? Quantity { get; set; }
    }
}
