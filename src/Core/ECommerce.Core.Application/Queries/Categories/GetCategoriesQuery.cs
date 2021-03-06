using ECommerce.Core.Application.Infrastructure.Dtos.CategoryDtos;
using MediatR;
using System.Collections.Generic;

namespace ECommerce.Core.Application.Queries.Categories
{
    public class GetCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }
}
