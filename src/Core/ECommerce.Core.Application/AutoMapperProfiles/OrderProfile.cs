using AutoMapper;
using ECommerce.Core.DataAccess.Entities;

namespace ECommerce.Core.Application.AutoMapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Cart, OrderProducts>()
                .ForMember(o => o.Price, source => source.MapFrom(c => c.Product.Price));
        }
    }
}
