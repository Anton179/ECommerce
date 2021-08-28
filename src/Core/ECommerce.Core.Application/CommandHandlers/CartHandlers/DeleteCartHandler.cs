using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Commands.CartCommands;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;

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

            var carts = _cartRepository.Read().Where(c => c.UserId == userId);

            _cartRepository.DeleteRange(carts);
            await _cartRepository.SaveChangesAsync();

            return userId;

        }
    }
}
