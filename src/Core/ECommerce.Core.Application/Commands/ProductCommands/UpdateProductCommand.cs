using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess.Dtos.CharacteristicsDtos;
using MediatR;

namespace ECommerce.Core.Application.Commands.ProductCommands
{
    public class UpdateProductCommand : IRequest<Guid>
    {
        [Required]
        public Guid? Id { get; set; }
        [StringLength(254)]
        [Required]
        public string Name { get; set; }
        [StringLength(254)]
        [Required]
        public string Description { get; set; }
        [Range(1, 4999)]
        public decimal Price { get; set; }
        [Range(0.1, 40)]
        public double Weight { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public bool? InStock { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual ICollection<CharacteristicValueDto> Characteristics { get; set; }
    }
}
