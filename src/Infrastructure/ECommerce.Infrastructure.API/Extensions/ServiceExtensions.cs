using ECommerce.Core.DataAccess.Interfaces;
using ECommerce.Core.DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
