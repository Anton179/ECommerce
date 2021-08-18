using System.Collections.Generic;
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
        public Dictionary<string, string> Characteristics { get; set; } = new Dictionary<string, string>();
        public virtual User User { get; set; }
    }
}
