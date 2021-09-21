using AutoMapper;
using ECommerce.Core.Application.Infrastructure.Dtos.ShippingMethodDtos;
using ECommerce.Core.DataAccess.Entities;

namespace ECommerce.Core.Application.AutoMapperProfiles
{
    public class ShippingMethodProfile : Profile
    {
        public ShippingMethodProfile()
        {
            CreateMap<ShippingMethod, ShippingMethodDto>();
        }
    }
}
