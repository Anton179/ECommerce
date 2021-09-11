using AutoMapper;
using ECommerce.Core.DataAccess.Dtos.OrderDtos;
using ECommerce.Core.DataAccess.Entities;

namespace ECommerce.Core.Application.AutoMapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Cart, OrderProducts>()
                .ForMember(o => o.Price, source => source.MapFrom(c => c.Product.Price));
            
            CreateMap<Order, OrderDto>();

            CreateMap<OrderProducts, OrderProductsDto>()
                .ForMember(o => o.Product, source => source.MapFrom(o => o.Product))
                .ForPath(o => o.Product.Price, source => source.MapFrom(o => o.Price));
        }
    }
}
