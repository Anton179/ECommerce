using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.DataAccess.Interfaces;
using ECommerce.Core.Application.Queries.Products;
using ECommerce.Core.DataAccess.Dtos.ProductDtos;
using ECommerce.Core.DataAccess.Entities;
using MediatR;

namespace ECommerce.Core.Application.QueryHandlers.Products
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductForDisplayDto>>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IGenericRepository<Product> productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductForDisplayDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.ListAsync(cancellationToken);

            var result = _mapper.Map<List<ProductForDisplayDto>>(products);

            return result;
        }
    }
}
