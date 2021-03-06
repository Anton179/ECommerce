using System.Reflection;
using ECommerce.Core.DataAccess;
using ECommerce.Core.DataAccess.Auth;
using ECommerce.Web.IdentityServer.Infrastructure.Factories;
using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ECommerce.Web.IdentityServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var migrationsAssembly = typeof(ECommerceDbContext).GetTypeInfo().Assembly.GetName().Name;
            var connectionString = Configuration.GetConnectionString("ECommerceConnection");

            services.AddControllersWithViews();

            services.AddDbContext<ECommerceDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
            })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<ECommerceDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserClaimsPrincipalFactory<User>, ClaimsFactory>();
            
            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
                .AddDeveloperSigningCredential()
                .AddConfigurationStore(builder =>
                {
                    builder.ConfigureDbContext = options => options.UseSqlServer(
                        connectionString,
                        opt => opt.MigrationsAssembly(migrationsAssembly)
                    );
                    builder.DefaultSchema = "is4";
                })
                .AddOperationalStore(builder =>
                {
                    builder.ConfigureDbContext = options => options.UseSqlServer(
                        connectionString,
                        opt => opt.MigrationsAssembly(migrationsAssembly)
                    );
                    builder.DefaultSchema = "is4";
                })
                .AddAspNetIdentity<User>();
            
            services.AddAuthentication()
                .AddGoogle("Google", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    options.ClientId = "865160400299-c9avcii9hm0mknksq96ou0aeulvj9thn.apps.googleusercontent.com";
                    options.ClientSecret = "vEG90kTIwW3XF6kLgLjVKHKS";
                });

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseIdentityServer();

            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }
    }
}
