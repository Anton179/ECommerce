using ECommerce.Core.DataAccess.Auth;
using ECommerce.Core.DataAccess.Enums;

namespace ECommerce.Core.DataAccess.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryEnum Category { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string ImageUrl { get; set; }
        public string Characteristics { get; set; }
        public virtual User User { get; set; }
    }
}
