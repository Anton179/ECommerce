using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Dtos.CategoryDtos;
using ECommerce.Core.Application.Queries.Categories;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;
using MediatR;

namespace ECommerce.Core.Application.QueryHandlers.Categories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, PaginatedResult<CategoryWithImageDto>>
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public GetCategoriesQueryHandler(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<PaginatedResult<CategoryWithImageDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var pageResult = await _categoryRepository.GetPagedData<CategoryWithImageDto>(request.PagedRequest);

            return pageResult;
        }
    }
}
