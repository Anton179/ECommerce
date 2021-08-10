using ECommerce.Core.Application.Interfaces;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Infrastructure.API.Providers
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly HttpContext _httpContext;

        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public Guid GetUserId()
        {
            var userId = _httpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;

            return new Guid(userId);
        }
    }
}
