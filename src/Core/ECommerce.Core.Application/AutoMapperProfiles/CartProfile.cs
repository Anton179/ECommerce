using AutoMapper;
using ECommerce.Core.Application.Commands.CartCommands;
using ECommerce.Core.DataAccess.Dtos.CartDtos;
using ECommerce.Core.DataAccess.Entities;

namespace ECommerce.Core.Application.AutoMapperProfiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CreateCartCommand, Cart>();
            CreateMap<Cart, CartDto>();
        }
    }
}
