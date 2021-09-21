using AutoMapper;
using ECommerce.Core.Application.Infrastructure.Dtos.UserDtos;
using ECommerce.Core.DataAccess.Auth;

namespace ECommerce.Core.Application.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
