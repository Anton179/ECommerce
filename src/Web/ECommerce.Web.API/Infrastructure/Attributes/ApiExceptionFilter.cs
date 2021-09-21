using ECommerce.Core.Application.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerce.Web.API.Infrastructure.Attributes
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ApiException apiException)
            {
                context.Result = new ObjectResult(apiException.Message) { StatusCode = (int)apiException.Code };
            }
        }
    }
}
