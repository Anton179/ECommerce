using ECommerce.Core.Application.Infrastructure.Exceptions;
using ECommerce.Core.Application.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net;

namespace ECommerce.Web.API.Infrastructure.Providers
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
            var userId = _httpContext.User.Claims.First(x => x.Type == "sub").Value;

            if (userId == null)
            {
                throw new ApiException(HttpStatusCode.Unauthorized, "You are not authorized!");
            }

            return new Guid(userId);
        }
    }
}
