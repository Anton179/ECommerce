﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.Core.DataAccess.Dtos.CharacteristicsDtos;
using ECommerce.Core.DataAccess.Dtos.ProductDtos;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Entities.CharacteristicsValue;
using MediatR;

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
        [Range(1, 4999)]
        public decimal Price { get; set; }
        [Range(0.1, 40)]
        public double Weight { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public Guid? CategoryId { get; set; }
        [Required]
        public virtual ICollection<CharacteristicValueDto> CharacteristicsValue { get; set; }
    }
}
