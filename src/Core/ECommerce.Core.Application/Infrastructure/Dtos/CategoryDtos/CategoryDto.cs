using ECommerce.Core.Application.Infrastructure.Dtos.CharacteristicsDtos;
using System;
using System.Collections.Generic;

namespace ECommerce.Core.Application.Infrastructure.Dtos.CategoryDtos
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public CategoryWithParentDto Parent { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<CategoryDto> SubCategories { get; set; }
        public virtual ICollection<CharacteristicDto> Characteristics { get; set; }
    }
}
