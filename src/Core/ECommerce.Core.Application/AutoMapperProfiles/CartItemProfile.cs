using AutoMapper;
using ECommerce.Core.Application.Commands.CartCommands;
using ECommerce.Core.Application.Infrastructure.Dtos.CartItemDtos;
using ECommerce.Core.DataAccess.Entities;

namespace ECommerce.Core.Application.AutoMapperProfiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<CreateCartItemCommand, CartItem>();
            CreateMap<CartItem, CartItemDto>();
        }
    }
}
