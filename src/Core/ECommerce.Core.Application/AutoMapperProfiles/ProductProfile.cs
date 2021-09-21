using AutoMapper;
using ECommerce.Core.Application.Commands.ProductCommands;
using ECommerce.Core.Application.Infrastructure.Dtos.ProductDtos;
using ECommerce.Core.DataAccess.Entities;

namespace ECommerce.Core.Application.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<Product, ProductForDisplayDto>()
                .ReverseMap();

            CreateMap<CreateProductCommand, ProductDto>();

            CreateMap<CreateProductCommand, Product>();
            
            CreateMap<Product, CreateProductCommand>();
        }
    }
}
