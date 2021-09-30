using System;
using System.Collections.Generic;
using ECommerce.Core.Application.Infrastructure.Dtos.CategoryDtos;
using ECommerce.Core.Application.Infrastructure.Dtos.CharacteristicsDtos;
using ECommerce.Core.Application.Infrastructure.Dtos.UserDtos;

namespace ECommerce.Core.Application.Infrastructure.Dtos.ProductDtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Weight { get; set; }
        public string ImagePath { get; set; }
        public bool InStock { get; set; }
        public virtual UserDto User { get; set; }
        public virtual CategoryWithParentDto Category { get; set; }
        public virtual ICollection<CharacteristicValueDto> Characteristics { get; set; }
    }
}
