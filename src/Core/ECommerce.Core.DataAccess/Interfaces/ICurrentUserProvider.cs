using System;

namespace ECommerce.Core.DataAccess.Interfaces
{
    public interface ICurrentUserProvider
    {
        Guid GetUserId();
    }
}
