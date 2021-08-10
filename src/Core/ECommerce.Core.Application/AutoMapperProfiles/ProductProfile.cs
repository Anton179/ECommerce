using AutoMapper;
using ECommerce.Core.Application.Commands.ProductCommands;
using ECommerce.Core.DataAccess.Dtos.Product;
using ECommerce.Core.DataAccess.Entities;
//using ECommerce.Core.Domain.ViewModels;

namespace ECommerce.Core.Application.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            //CreateMap<Product, ProductForCreateDto>();
            CreateMap<CreateProductCommand, ProductDto>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, CreateProductCommand>();
        }
    }
}
