using System;
using System.Collections.Generic;
using ECommerce.Core.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Core.DataAccess.Auth
{
    public class User : IdentityUser<Guid>
    {
        public virtual ICollection<Product> Products { get; set; }
        public bool IsActive { get; set; }
    }
}
