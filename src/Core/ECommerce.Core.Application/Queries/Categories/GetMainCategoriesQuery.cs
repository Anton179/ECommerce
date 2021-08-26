using System.Collections.Generic;
using ECommerce.Core.DataAccess.Dtos.CategoryDtos;
using MediatR;

namespace ECommerce.Core.Application.Queries.Categories
{
    public class GetMainCategoriesQuery : IRequest<IEnumerable<CategoryWithImageDto>>
    {

    }
}
