using AutoMapper;
using ECommerce.Core.Application.Queries.CartQueries;
using ECommerce.Core.DataAccess.Dtos.CartDtos;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Core.Application.QueryHandlers.CartHandlers
{
    public class CartHandler : IRequestHandler<CartQuery, IEnumerable<CartDto>>
    {
        private readonly IGenericRepository<Cart> _cartRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserProvider _currentUserProvider;

        public CartHandler(IGenericRepository<Cart> cartRepository,
            IMapper mapper, ICurrentUserProvider currentUserProvider)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _currentUserProvider = currentUserProvider;
        }

        public async Task<IEnumerable<CartDto>> Handle(CartQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var userId = _currentUserProvider.GetUserId();

            var carts = await _cartRepository.Read().Where(c => c.UserId == userId).ToListAsync(cancellationToken);

            var result = _mapper.Map<IEnumerable<CartDto>>(carts);

            return result;
        }
    }
}
