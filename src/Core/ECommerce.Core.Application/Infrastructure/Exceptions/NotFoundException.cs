using System.Net;

namespace ECommerce.Core.Application.Infrastructure.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(string message) : base(HttpStatusCode.NotFound, message)
        {
        }
    }
}
