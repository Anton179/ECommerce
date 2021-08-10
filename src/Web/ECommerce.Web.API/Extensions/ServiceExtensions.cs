using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Core.Application.Interfaces;
using ECommerce.Infrastructure.API.Configuration;
using ECommerce.Infrastructure.API.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.Web.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }

        public static void AddJwtAuthentication(this IServiceCollection services, AuthOptions authOptions)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = authOptions.Issuer,

                    ValidateAudience = true,
                    ValidAudience = authOptions.Audience,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                };
            });
        }

        public static AuthOptions ConfigureAuthOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var authOptionsConfigurationSection = configuration.GetSection("AuthOptions");
            services.Configure<AuthOptions>(authOptionsConfigurationSection);
            var authOptions = authOptionsConfigurationSection.Get<AuthOptions>();
            return authOptions;
        }
    }
}
