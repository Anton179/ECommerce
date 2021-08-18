using AutoMapper;
using ECommerce.Core.Application.Commands.ProductCommands;
using ECommerce.Core.Application.Interfaces;
using ECommerce.Core.DataAccess.Auth;
using ECommerce.Core.DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Core.Application.CommandHandlers.ProductHandlers
{
    public class CreateProductHandler : BaseCreateUpdateProductHandler, IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserProvider _currentUserProvider;

        public CreateProductHandler(IGenericRepository<Product> repository, IMapper mapper,
            IMediator mediator,
            ICurrentUserProvider currentUserProvider) : base(mediator)
        {
            _productRepository = repository;
            _mapper = mapper;
            _currentUserProvider = currentUserProvider;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            product.OwnerId = _currentUserProvider.GetUserId();

            await _productRepository.AddAsync(product, cancellationToken);
            await _productRepository.SaveChangesAsync();

            return product.Id;
        }
    }
}
