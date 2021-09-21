using AutoMapper;
using ECommerce.Core.Application.Queries.Products;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Dtos.ProductDtos;
using ECommerce.Core.Application.Infrastructure.Exceptions;

namespace ECommerce.Core.Application.QueryHandlers.Products
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IGenericRepository<Product> productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

            if (product == null)
            {
                throw new NotFoundException("The product doesn't exist!");
            }

            var result = _mapper.Map<ProductDto>(product);

            return result;
        }
    }
}
