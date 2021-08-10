using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Infrastructure.API.Authorization.Attributes
{
    public class WriteAttribute : AuthorizeAttribute
    {
        public WriteAttribute() : base("write") { }
    }
}
