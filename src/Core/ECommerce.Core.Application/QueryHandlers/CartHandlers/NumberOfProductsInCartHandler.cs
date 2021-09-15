using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Queries.CartQueries;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Core.Application.QueryHandlers.CartHandlers
{
    public class NumberOfProductsInCartHandler : IRequestHandler<NumberOfProductsInCartQuery, int>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IGenericRepository<Cart> _cartRepository;

        public NumberOfProductsInCartHandler(ICurrentUserProvider currentUserProvider, IGenericRepository<Cart> cartRepository)
        {
            _currentUserProvider = currentUserProvider;
            _cartRepository = cartRepository;
        }
        public async Task<int> Handle(NumberOfProductsInCartQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var userId = _currentUserProvider.GetUserId();

            var count = await _cartRepository.Read().Where(c => c.UserId == userId).SumAsync(c => c.Quantity, cancellationToken);

            return count;
        }
    }
}
