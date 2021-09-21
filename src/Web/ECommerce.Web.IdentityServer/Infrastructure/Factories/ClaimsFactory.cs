using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess.Auth;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ECommerce.Web.IdentityServer.Infrastructure.Factories
{
    public class ClaimsFactory : UserClaimsPrincipalFactory<User>
    {
        private readonly UserManager<User> _userManager;

        public ClaimsFactory(
            UserManager<User> userManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
            _userManager = userManager;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            identity.AddClaims(Enumerable.Select<string, Claim>(roles, role => new Claim(JwtClaimTypes.Role, role)));

            return identity;
        }
    }
}
