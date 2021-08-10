using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Infrastructure.API.Authorization.Attributes
{
    public class FullAttribute : AuthorizeAttribute
    {
        public FullAttribute() : base("full") { }
    }
}
