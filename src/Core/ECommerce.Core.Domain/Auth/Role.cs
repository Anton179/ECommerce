using System;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Core.DataAccess.Auth
{
    public class Role : IdentityRole<Guid>
    {
        public Role(string roleName) : base(roleName) { }
        public Role() : base() { }
    }
}
