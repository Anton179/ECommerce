using System;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Core.DataAccess.Auth
{
    public class UserToken : IdentityUserToken<Guid>
    {
    }
}
