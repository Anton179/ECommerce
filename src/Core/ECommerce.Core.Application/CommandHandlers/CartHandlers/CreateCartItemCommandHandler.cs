using AutoMapper;
using ECommerce.Core.Application.Commands.CartCommands;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Interfaces;

namespace ECommerce.Core.Application.CommandHandlers.CartHandlers
{
    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IGenericRepository<CartItem> _cartRepository;

        public CreateCartItemCommandHandler(IMapper mapper, ICurrentUserProvider currentUserProvider,
            IGenericRepository<CartItem> genericRepository)
        {
            _mapper = mapper;
            _currentUserProvider = currentUserProvider;
            _cartRepository = genericRepository;
        }

        public async Task<Guid> Handle(CreateCartItemCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var cart = _mapper.Map<CartItem>(request);

            cart.UserId = _currentUserProvider.GetUserId();

            var product = await _cartRepository.Read().FirstOrDefaultAsync(c => c.UserId == cart.UserId && c.ProductId == cart.ProductId);

            if (product != null)
            {
                product.Quantity += cart.Quantity;
                _cartRepository.Update(product);
            }
            else
            {
                await _cartRepository.AddAsync(cart);
            }
            await _cartRepository.SaveChangesAsync();

            return cart.Id;
        }
    }
}
