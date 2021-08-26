using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.DataAccess.Dtos.CategoryDtos;
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
