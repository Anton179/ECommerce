using System.Collections.Generic;

namespace ECommerce.Core.DataAccess.Dtos.CategoryDtos
{
    public class CategoryWithSubCategoriesDto
    {
        public string Name { get; set; }
        public virtual ICollection<CategoryWithSubCategoriesDto> SubCategories { get; set; }
    }
}
