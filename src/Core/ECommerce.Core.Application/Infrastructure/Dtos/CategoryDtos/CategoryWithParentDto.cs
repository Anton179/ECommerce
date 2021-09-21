namespace ECommerce.Core.Application.Infrastructure.Dtos.CategoryDtos
{
    public class CategoryWithParentDto
    {
        public string Name { get; set; }
        public virtual CategoryWithParentDto Parent { get; set; }
    }
}
