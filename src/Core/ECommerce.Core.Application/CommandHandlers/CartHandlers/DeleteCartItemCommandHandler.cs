using ECommerce.Core.Application.Commands.CartCommands;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Exceptions;
using ECommerce.Core.Application.Infrastructure.Interfaces;

namespace ECommerce.Core.Application.CommandHandlers.CartHandlers
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, Guid>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IGenericRepository<CartItem> _cartRepository;

        public DeleteCartItemCommandHandler(ICurrentUserProvider currentUserProvider, IGenericRepository<CartItem> cartRepository)
        {
            _currentUserProvider = currentUserProvider;
            _cartRepository = cartRepository;
        }

        public async Task<Guid> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var userId = _currentUserProvider.GetUserId();

            var cart = await _cartRepository.Read().Where(c => c.UserId == userId && c.ProductId == request.ProductId).FirstOrDefaultAsync();

            if (cart == null)
            {
                throw new NotFoundException("The product does not exist in cart");
            }

            _cartRepository.Delete(cart);
            await _cartRepository.SaveChangesAsync();

            return userId;

        }
    }
}
