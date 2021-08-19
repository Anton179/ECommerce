﻿using ECommerce.Core.DataAccess.Interfaces;
using System;
using System.Linq;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authentication;
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

            var userId = _httpContext.User.Claims.FirstOrDefault(x => x.Type == "sub").Value;

            return new Guid(userId);
        }
    }
}