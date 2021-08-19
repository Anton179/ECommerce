using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.DataAccess.Interfaces;
using ECommerce.Core.Application.Queries.Products;
using ECommerce.Core.DataAccess.Dtos.Product;
using ECommerce.Core.DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

            var result = _mapper.Map<ProductDto>(product);

            return result;
        }
    }
}
