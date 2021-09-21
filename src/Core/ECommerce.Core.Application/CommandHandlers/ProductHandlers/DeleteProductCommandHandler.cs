using ECommerce.Core.Application.Commands.ProductCommands;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Exceptions;
using ECommerce.Core.Application.Infrastructure.Interfaces;

namespace ECommerce.Core.Application.CommandHandlers.ProductHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Guid>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly ICurrentUserProvider _currentUserProvider;

        public DeleteProductCommandHandler(IGenericRepository<Product> productRepository, ICurrentUserProvider currentUserProvider)
        {
            _productRepository = productRepository;
            _currentUserProvider = currentUserProvider;
        }
        public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
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
