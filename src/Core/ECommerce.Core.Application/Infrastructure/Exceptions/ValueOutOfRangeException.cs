using System.Net;

namespace ECommerce.Core.Application.Infrastructure.Exceptions
{
    public class ValueOutOfRangeException : ApiException
    {
        public ValueOutOfRangeException(string message) : base(HttpStatusCode.BadRequest, message)
        {
        }
    }
}
