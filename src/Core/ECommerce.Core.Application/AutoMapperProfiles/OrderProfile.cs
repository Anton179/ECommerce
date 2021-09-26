using AutoMapper;
using ECommerce.Core.Application.Commands.OrderCommands;
using ECommerce.Core.Application.Infrastructure.Dtos.OrderDtos;
using ECommerce.Core.DataAccess.Entities;

namespace ECommerce.Core.Application.AutoMapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CartItem, OrderProducts>()
                .ForMember(o => o.Price, source => source.MapFrom(c => c.Product.Price));

            CreateMap<Order, OrderDto>();

            CreateMap<UpdateOrderCommand, Order>();

            CreateMap<OrderProducts, OrderProductsDto>()
                .ForMember(o => o.Product, source => source.MapFrom(o => o.Product))
                .ForPath(o => o.Product.Price, source => source.MapFrom(o => o.Price));

            CreateMap<OrderProductsDto, OrderProducts>()
                .ForMember(o => o.ProductId, source => source.MapFrom(o => o.Product.Id))
                .ForPath(o => o.Price, source => source.MapFrom(o => o.Product.Price));

            CreateMap<OrderProductsDto, OrderProductForCreateDto>()
                .ForMember(o => o.ProductId, source => source.MapFrom(o => o.Product.Id))
                .ForPath(o => o.Price, source => source.MapFrom(o => o.Product.Price));

            CreateMap<OrderProducts, OrderProductForVendorDtos>()
                .ForMember(o => o.User, source => source.MapFrom(o => o.Order.User))
                .ForMember(o => o.Status, source => source.MapFrom(o => o.Order.Status));

            CreateMap<OrderProductForCreateDto, OrderProducts>();
        }
    }
}
