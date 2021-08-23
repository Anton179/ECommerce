using System;
using System.Collections.Generic;
using ECommerce.Core.DataAccess.Auth;
using ECommerce.Core.DataAccess.Entities.Characteristics;
using ECommerce.Core.DataAccess.Enums;

namespace ECommerce.Core.DataAccess.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string ImageUrl { get; set; }
        public virtual User User { get; set; }
        public Guid OwnerId { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Characteristic> Characteristics { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
