using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.Core.Application.Infrastructure.Dtos.CharacteristicsDtos;
using ECommerce.Core.DataAccess.Entities;

namespace ECommerce.Core.Application.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        [Required]
        [StringLength(140)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(0.1, 5000)]
        public double Weight { get; set; }
        [Required]
        public bool? InStock { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public Guid? CategoryId { get; set; }
        [Required]
        public virtual ICollection<CharacteristicValueDto> Characteristics { get; set; }
    }
}
