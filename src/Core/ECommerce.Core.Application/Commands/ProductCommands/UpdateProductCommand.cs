using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.Core.Application.Infrastructure.Dtos.CharacteristicsDtos;

namespace ECommerce.Core.Application.Commands.ProductCommands
{
    public class UpdateProductCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        [StringLength(140)]
        [Required]
        public string Name { get; set; }
        [StringLength(500)]
        [Required]
        public string Description { get; set; }
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(0.1, 5000)]
        public double Weight { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public bool? InStock { get; set; }
        [Required]
        public Guid? CategoryId { get; set; }
        [Required]
        public virtual ICollection<CharacteristicValueDto> Characteristics { get; set; }
    }
}
