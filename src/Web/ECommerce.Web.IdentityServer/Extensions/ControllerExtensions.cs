using ECommerce.Core.DataAccess.ViewModels.Account;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ECommerce.Web.IdentityServer.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult LoadingPage(this Controller controller, string viewName, string redirectUri)
        {
            controller.HttpContext.Response.StatusCode = 200;
            controller.HttpContext.Response.Headers["Location"] = "";

            return controller.View(viewName, new RedirectViewModel { RedirectUrl = redirectUri });
        }
    }
}
