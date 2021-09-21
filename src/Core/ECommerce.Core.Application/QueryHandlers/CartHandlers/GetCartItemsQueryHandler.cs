using AutoMapper;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Dtos.CartItemDtos;
using ECommerce.Core.Application.Infrastructure.Interfaces;
using ECommerce.Core.Application.Queries.CartQueries;

namespace ECommerce.Core.Application.QueryHandlers.CartHandlers
{
    public class GetCartItemsQueryHandler : IRequestHandler<GetCartItemsQuery, IEnumerable<CartItemDto>>
    {
        private readonly IGenericRepository<CartItem> _cartRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserProvider _currentUserProvider;

        public GetCartItemsQueryHandler(IGenericRepository<CartItem> cartRepository,
            IMapper mapper, ICurrentUserProvider currentUserProvider)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _currentUserProvider = currentUserProvider;
        }

        public async Task<IEnumerable<CartItemDto>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var userId = _currentUserProvider.GetUserId();

            var carts = await _cartRepository.Read().Where(c => c.UserId == userId).ToListAsync(cancellationToken);

            var result = _mapper.Map<IEnumerable<CartItemDto>>(carts);

            return result;
        }
    }
}
