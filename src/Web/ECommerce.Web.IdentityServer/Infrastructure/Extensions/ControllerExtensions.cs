using ECommerce.Web.IdentityServer.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.IdentityServer.Infrastructure.Extensions
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
