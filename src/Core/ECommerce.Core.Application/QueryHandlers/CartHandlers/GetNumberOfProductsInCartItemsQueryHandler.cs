using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Interfaces;
using ECommerce.Core.Application.Queries.CartQueries;

namespace ECommerce.Core.Application.QueryHandlers.CartHandlers
{
    public class GetNumberOfProductsInCartItemsQueryHandler : IRequestHandler<GetNumberOfProductsInCartItemsQuery, int>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IGenericRepository<CartItem> _cartRepository;

        public GetNumberOfProductsInCartItemsQueryHandler(ICurrentUserProvider currentUserProvider, IGenericRepository<CartItem> cartRepository)
        {
            _currentUserProvider = currentUserProvider;
            _cartRepository = cartRepository;
        }
        public async Task<int> Handle(GetNumberOfProductsInCartItemsQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var userId = _currentUserProvider.GetUserId();

            var count = await _cartRepository.Read().Where(c => c.UserId == userId).SumAsync(c => c.Quantity, cancellationToken);

            return count;
        }
    }
}
