using System.Net;

namespace ECommerce.Core.Application.Infrastructure.Exceptions
{
    public class NoAccessException : ApiException
    {
        public NoAccessException() : base(HttpStatusCode.Forbidden, "You don't have permission to access this resource.")
        {
        }
    }
}
