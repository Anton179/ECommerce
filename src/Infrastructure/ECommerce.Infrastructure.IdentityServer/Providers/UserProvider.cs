using ECommerce.Core.DataAccess.Auth;
using ECommerce.Core.DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.IdentityServer.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly UserManager<User> _userManager;

        public UserProvider(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetUserById(Guid Id)
        {
            return await _userManager.FindByIdAsync(Id.ToString());
        }
    }
}
