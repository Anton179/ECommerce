using ECommerce.Core.Application.Commands.CartCommands;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Interfaces;

namespace ECommerce.Core.Application.CommandHandlers.CartHandlers
{
    public class DeleteAllCartItemsCommandHandler : IRequestHandler<DeleteAllCartItemsCommand, Guid>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IGenericRepository<CartItem> _cartRepository;

        public DeleteAllCartItemsCommandHandler(ICurrentUserProvider currentUserProvider, IGenericRepository<CartItem> cartRepository)
        {
            _currentUserProvider = currentUserProvider;
            _cartRepository = cartRepository;
        }

        public async Task<Guid> Handle(DeleteAllCartItemsCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var userId = _currentUserProvider.GetUserId();

            var carts = _cartRepository.Read().Where(c => c.UserId == userId);

            _cartRepository.DeleteRange(carts);
            await _cartRepository.SaveChangesAsync();

            return userId;
        }
    }
}
