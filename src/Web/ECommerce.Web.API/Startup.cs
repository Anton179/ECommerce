using System.IO;
using ECommerce.Core.Application.AutoMapperProfiles;
using ECommerce.Core.Application.CommandHandlers.ProductHandlers;
using ECommerce.Core.DataAccess;
using ECommerce.Core.DataAccess.Interfaces;
using ECommerce.Infrastructure.API.Providers;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using ECommerce.Infrastructure.API.Extensions;
using ECommerce.Infrastructure.API.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;

namespace ECommerce.Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerce.Web.API", Version = "v1" });
            });

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:5000/";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "ECommerce.Web.API";
                    options.ApiSecret = "A1837CD3-TCDProject-5340-API-4B40-Resource-BE7C-55E5B5C9FAAB";
                });

            services.AddCors();
            services.AddDbContext<ECommerceDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ECommerceConnection"));
                options.UseLazyLoadingProxies();
            });

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly(), typeof(ProductProfile).Assembly);

            services.AddRepositories();
            services.AddHttpContextAccessor();
            services.AddTransient<ICurrentUserProvider, CurrentUserProvider>();
            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(CreateProductHandler).Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce.Web.API v1"));
            }
            else
            {
                app.UseErrorHandling();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
