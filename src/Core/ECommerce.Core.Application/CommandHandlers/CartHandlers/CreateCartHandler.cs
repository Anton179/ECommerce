using AutoMapper;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Commands.CartCommands;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Core.Application.CommandHandlers.CartHandlers
{
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IGenericRepository<Cart> _cartRepository;

        public CreateCartHandler(IMapper mapper, ICurrentUserProvider currentUserProvider,
            IGenericRepository<Cart> genericRepository)
        {
            _mapper = mapper;
            _currentUserProvider = currentUserProvider;
            _cartRepository = genericRepository;
        }
        public async Task<Guid> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = _mapper.Map<Cart>(request);

            cart.UserId = _currentUserProvider.GetUserId();

            var product = await _cartRepository.Read().FirstOrDefaultAsync(c => c.UserId == cart.UserId && c.ProductId == cart.ProductId, cancellationToken);

            if (product != null)
            {
                product.Quantity += cart.Quantity;
                _cartRepository.Update(product);
            }
            else
            {
                await _cartRepository.AddAsync(cart, cancellationToken);

            }
            await _cartRepository.SaveChangesAsync();

            return cart.Id;
        }
    }
}
