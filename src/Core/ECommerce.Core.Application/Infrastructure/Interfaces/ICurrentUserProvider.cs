using System;

namespace ECommerce.Core.Application.Infrastructure.Interfaces
{
    public interface ICurrentUserProvider
    {
        Guid GetUserId();
    }
}
