using System;

namespace ECommerce.Core.Application.Infrastructure.Dtos.CategoryDtos
{
    public class CategoryWithImageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
