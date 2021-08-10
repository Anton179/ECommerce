using System;

namespace ECommerce.Core.Application.Interfaces
{
    public interface ICurrentUserProvider
    {
        Guid GetUserId();
    }
}
