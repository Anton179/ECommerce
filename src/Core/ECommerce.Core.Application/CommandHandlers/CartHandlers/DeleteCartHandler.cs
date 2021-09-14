using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Commands.CartCommands;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using ECommerce.Infrastructure.API.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Core.Application.CommandHandlers.CartHandlers
{
    public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, Guid>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IGenericRepository<Cart> _cartRepository;

        public DeleteCartHandler(ICurrentUserProvider currentUserProvider, IGenericRepository<Cart> cartRepository)
        {
            _currentUserProvider = currentUserProvider;
            _cartRepository = cartRepository;
        }

        public async Task<Guid> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserProvider.GetUserId();

            var cart = await _cartRepository.Read().Where(c => c.UserId == userId && c.ProductId == request.ProductId).FirstOrDefaultAsync(cancellationToken);

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
