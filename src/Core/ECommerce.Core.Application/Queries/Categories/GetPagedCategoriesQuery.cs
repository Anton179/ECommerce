using ECommerce.Core.Application.Infrastructure.Dtos.CategoryDtos;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;
using MediatR;

namespace ECommerce.Core.Application.Queries.Categories
{
    public class GetPagedCategoriesQuery : PagedRequest, IRequest<PaginatedResult<CategoryDto>>
    {
    }
}
