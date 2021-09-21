using System;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess;
using ECommerce.Core.DataAccess.Auth;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ECommerce.Web.IdentityServer.Infrastructure.Extensions
{
    public static class HostExtensions
    {
        public static async Task<IHost> SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var configurationContext = services.GetRequiredService<ConfigurationDbContext>();
                    var ecommerceDbContext = services.GetRequiredService<ECommerceDbContext>();
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager = services.GetRequiredService<RoleManager<Role>>();


                    await Seed.SeedIdentityRoles(roleManager);
                    await Seed.SeedIdentityUsers(userManager);
                    await Seed.SeedIdentityServer(configurationContext);
                    await Seed.SeedApiServer(ecommerceDbContext);
                }
                catch (Exception exception)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "An error occurred during filling the table");
                }
            }

            return host;
        }
    }
}
