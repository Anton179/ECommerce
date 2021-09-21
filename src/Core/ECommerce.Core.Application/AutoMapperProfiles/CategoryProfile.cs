using AutoMapper;
using ECommerce.Core.Application.Infrastructure.Dtos.CategoryDtos;
using ECommerce.Core.DataAccess.Entities;

namespace ECommerce.Core.Application.AutoMapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryWithParentDto>();
            CreateMap<Category, CategoryWithSubCategoriesDto>();
            CreateMap<Category, CategoryWithImageDto>();
        }
    }
}
