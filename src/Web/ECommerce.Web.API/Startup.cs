using ECommerce.Core.Application.AutoMapperProfiles;
using ECommerce.Core.Application.CommandHandlers.ProductHandlers;
using ECommerce.Core.Application.Interfaces;
using ECommerce.Core.DataAccess;
using ECommerce.Core.DataAccess.Auth;
using ECommerce.Infrastructure.API.Providers;
using ECommerce.Web.API.Extensions;
using IdentityServer4.AccessTokenValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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

            //services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //    .AddIdentityServerAuthentication(options =>
            //    {
            //        options.Authority = "https://localhost:5000/";
            //        options.RequireHttpsMetadata = false;
            //        options.ApiName = "ECommerce.Web.API";
            //        options.ApiSecret = "A1837CD3-TCDProject-5340-API-4B40-Resource-BE7C-55E5B5C9FAAB";
            //    });

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

            //services.AddControllers(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();

            //    options.Filters.Add(new AuthorizeFilter(policy));
            //});

            services.AddCors();
            services.AddDbContext<ECommerceDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ECommerceConnection"));
                options.UseLazyLoadingProxies();
            });


            //services.AddIdentity<User, Role>(options =>
            //    {
            //        options.Password.RequiredLength = 8;
            //        options.Password.RequireNonAlphanumeric = false;
            //        options.Password.RequireLowercase = false;
            //        options.Password.RequireUppercase = false;
            //        options.User.RequireUniqueEmail = true;
            //    })
            //    .AddRoles<Role>()
            //    .AddEntityFrameworkStores<ECommerceDbContext>()
            //    .AddDefaultTokenProviders();

            //var authOptions = services.ConfigureAuthOptions(Configuration);
            //services.AddJwtAuthentication(authOptions);

            //services.Configure<FormOptions>(o =>
            //{
            //    o.ValueLengthLimit = int.MaxValue;
            //    o.MultipartBodyLengthLimit = int.MaxValue;
            //    o.MemoryBufferThreshold = int.MaxValue;
            //});

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Permission", policy =>
            //         policy.Requirements.Add(new OperationAuthorizationRequirement()));
            //});



            services.AddAutoMapper(Assembly.GetExecutingAssembly(), typeof(ProductProfile).Assembly);

            services.AddRepositories();
            services.AddHttpContextAccessor();
            services.AddTransient<ICurrentUserProvider, CurrentUserProvider>();
            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(BaseCreateUpdateProductHandler).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce.Web.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.ApplicationServices.GetRequiredService<ICurrentUserProvider>();

        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TheCodeBuzz-Service", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}

                    }
                });
            });
        }
    }
}
