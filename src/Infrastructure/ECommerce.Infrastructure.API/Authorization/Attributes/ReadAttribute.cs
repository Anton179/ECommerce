using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Infrastructure.API.Authorization.Attributes
{
    public class ReadAttribute : AuthorizeAttribute
    {

        public ReadAttribute() : base("read") { }
    }
}
