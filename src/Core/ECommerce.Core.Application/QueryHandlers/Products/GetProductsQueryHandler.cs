using System.Collections.Generic;
using System.Linq;
using ECommerce.Core.Application.Queries.Products;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Dtos.ProductDtos;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;
using ECommerce.Core.DataAccess.Models.PagedRequestModels.FilterEnums;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Core.Application.QueryHandlers.Products
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PaginatedResult<ProductForDisplayDto>>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly List<string> _categoryList = new List<string>();

        public GetProductsQueryHandler(IGenericRepository<Product> productRepository, IGenericRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<PaginatedResult<ProductForDisplayDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var categoryFilter = request.RequestFilters?.Filters?.FirstOrDefault(x => x.Path == "Category.Name");
            
            if (categoryFilter != null)
            {
                var category = await _categoryRepository.Read().FirstOrDefaultAsync(x => x.Name == categoryFilter.Value, cancellationToken);

                if (category.SubCategories.Any())
                {
                    GetSubCategoryNames(category.SubCategories);
                    _categoryList.Add(category.Name);

                    var idx = request.RequestFilters.Filters.IndexOf(categoryFilter);

                    request.RequestFilters.Filters[idx].Path = GetCustomCategoryFilterPath(_categoryList);
                    request.RequestFilters.Filters[idx].Operator = FilterOperators.Custom;
                }
                
            }

            var result = await _productRepository.GetPagedData<ProductForDisplayDto>(request);

            return result;
        }

        private void GetSubCategoryNames(ICollection<Category> categories)
        {

            foreach (var category in categories)
            {
                if (category.SubCategories.Any())
                {
                    GetSubCategoryNames(category.SubCategories);
                }

                _categoryList.Add(category.Name);
            }
        }

        private string GetCustomCategoryFilterPath(List<string> categoriesName)
        {
            var categoryFilter = "(";

            for (int i = 0; i < categoriesName.Count; i++)
            {
                categoryFilter += $"Category.Name.Equals(\"{categoriesName[i]}\")";

                if (i != categoriesName.Count - 1)
                {
                    categoryFilter += " Or ";
                }
            }

            return categoryFilter + ") ";
        }
    }
}
