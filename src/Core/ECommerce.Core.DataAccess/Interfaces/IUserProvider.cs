using ECommerce.Core.DataAccess.Auth;
using System;
using System.Threading.Tasks;

namespace ECommerce.Core.DataAccess.Interfaces
{
    public interface IUserProvider
    {
        Task<User> GetUserById(Guid Id);
    }
}
