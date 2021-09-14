using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.Application.Commands.ProductCommands;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using ECommerce.Infrastructure.API.Exceptions;
using MediatR;

namespace ECommerce.Core.Application.CommandHandlers.ProductHandlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Guid>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly ICurrentUserProvider _currentUserProvider;

        public DeleteProductHandler(IGenericRepository<Product> productRepository, ICurrentUserProvider currentUserProvider)
        {
            _productRepository = productRepository;
            _currentUserProvider = currentUserProvider;
        }
        public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            var userId = _currentUserProvider.GetUserId();

            if (product == null || product.OwnerId != userId)
            {
                throw new NotFoundException("The product does not exist");
            }

            _productRepository.Delete(product);

            await _productRepository.SaveChangesAsync();

            return request.Id;
        }
    }
}
