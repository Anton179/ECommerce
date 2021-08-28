using AutoMapper;
using ECommerce.Core.Application.Commands.ProductCommands;
using ECommerce.Core.DataAccess.Dtos.ProductDtos;
using ECommerce.Core.DataAccess.Entities;

namespace ECommerce.Core.Application.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductForDisplayDto>();
            CreateMap<CreateProductCommand, ProductDto>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, CreateProductCommand>();
        }
    }
}
