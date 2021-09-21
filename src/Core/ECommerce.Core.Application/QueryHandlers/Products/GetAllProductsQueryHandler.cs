using ECommerce.Core.Application.Queries.Products;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Dtos.ProductDtos;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;

namespace ECommerce.Core.Application.QueryHandlers.Products
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PaginatedResult<ProductForDisplayDto>>
    {
        private readonly IGenericRepository<Product> _productRepository;

        public GetAllProductsQueryHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PaginatedResult<ProductForDisplayDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await _productRepository.GetPagedData<ProductForDisplayDto>(request.PagedRequest);

            return result;
        }
    }
}
