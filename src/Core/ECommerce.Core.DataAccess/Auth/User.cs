using System;
using System.Collections.Generic;
using ECommerce.Core.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Core.DataAccess.Auth
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ushort Age { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<CartItem> Carts { get; set; }
        public bool IsActive { get; set; }
    }
}
