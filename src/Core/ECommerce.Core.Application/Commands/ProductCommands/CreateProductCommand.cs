using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.Core.Application.Infrastructure.Dtos.CharacteristicsDtos;

namespace ECommerce.Core.Application.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        [Required]
        [StringLength(254)]
        public string Name { get; set; }
        [Required]
        [StringLength(254)]
        public string Description { get; set; }
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(0.1, 5000)]
        public double Weight { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public Guid? CategoryId { get; set; }
        [Required]
        public virtual ICollection<CharacteristicValueDto> CharacteristicsValue { get; set; }
    }
}
