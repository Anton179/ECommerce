using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.DataAccess.Interfaces;
using ECommerce.Core.Application.Queries.Products;
using ECommerce.Core.DataAccess.Dtos.ProductDtos;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;
using MediatR;

namespace ECommerce.Core.Application.QueryHandlers.Products
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PaginatedResult<ProductForDisplayDto>>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IGenericRepository<Product> productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<ProductForDisplayDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {

            var result = await _productRepository.GetPagedData<ProductForDisplayDto>(request.PagedRequest);

            return result;
        }
    }
}
