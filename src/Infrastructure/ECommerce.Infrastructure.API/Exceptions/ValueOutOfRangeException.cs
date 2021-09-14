using System.Net;

namespace ECommerce.Infrastructure.API.Exceptions
{
    public class ValueOutOfRangeException : ApiException
    {
        public ValueOutOfRangeException(string message) : base(HttpStatusCode.BadRequest, message)
        {
        }
    }
}
