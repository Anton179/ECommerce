using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ECommerce.Web.API.Extensions
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
                    var ecommerceDbContext = services.GetRequiredService<ECommerceDbContext>();

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
