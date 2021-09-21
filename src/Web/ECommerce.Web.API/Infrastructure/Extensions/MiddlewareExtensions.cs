using ECommerce.Web.API.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace ECommerce.Web.API.Infrastructure.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
