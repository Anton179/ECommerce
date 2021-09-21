using MediatR;
using System.Collections.Generic;
using ECommerce.Core.Application.Infrastructure.Dtos.CategoryDtos;

namespace ECommerce.Core.Application.Queries.Categories
{
    public class GetMainCategoriesQuery : IRequest<IEnumerable<CategoryWithImageDto>>
    {

    }
}
