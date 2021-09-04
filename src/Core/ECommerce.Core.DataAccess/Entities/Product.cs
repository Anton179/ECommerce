﻿using ECommerce.Core.DataAccess.Auth;
using ECommerce.Core.DataAccess.Entities.CharacteristicsValue;
using System;
using System.Collections.Generic;

namespace ECommerce.Core.DataAccess.Entities
{
    public class Product : BaseEntity
    {
        public Guid OwnerId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string ImageUrl { get; set; }
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<CharacteristicValue> Characteristics { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}