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
    public class GetPagedCategoriesQueryHandler : IRequestHandler<GetPagedCategoriesQuery, PaginatedResult<CategoryDto>>
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public GetPagedCategoriesQueryHandler(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<PaginatedResult<CategoryDto>> Handle(GetPagedCategoriesQuery request, CancellationToken cancellationToken)
        {
            var pageResult = await _categoryRepository.GetPagedData<CategoryDto>(request);

            return pageResult;
        }
    }
}
