using System;
using System.Collections.Generic;

namespace ECommerce.Core.DataAccess.Entities
{
    public class Category : BaseEntity
    {
        public Guid? ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<Characteristic> Characteristics { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
