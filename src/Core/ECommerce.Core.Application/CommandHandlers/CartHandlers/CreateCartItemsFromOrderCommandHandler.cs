using ECommerce.Core.Application.Commands.CartCommands;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Interfaces;

namespace ECommerce.Core.Application.CommandHandlers.CartHandlers
{
    public class CreateCartItemsFromOrderCommandHandler : IRequestHandler<CreateCartItemsFromOrderCommand, Guid>
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<CartItem> _cartRepository;
        private readonly ICurrentUserProvider _currentUserProvider;

        public CreateCartItemsFromOrderCommandHandler(IGenericRepository<Order> orderRepository, IGenericRepository<CartItem> cartRepository,
                                  ICurrentUserProvider currentUserProvider)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _currentUserProvider = currentUserProvider;
        }
        public async Task<Guid> Handle(CreateCartItemsFromOrderCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserProvider.GetUserId();

            List<CartItem> cartList = await _orderRepository.Read()
                                                         .Where(o => o.Id == request.Id)
                                                         .SelectMany(o => o.OrderProducts,
                                                             (o, p) => new CartItem
                                                             {
                                                                 ProductId = p.ProductId,
                                                                 Quantity = p.Quantity,
                                                                 UserId = userId
                                                             }).ToListAsync();

            List<CartItem> currentCartList = await _cartRepository.Read().Where(c => c.UserId == userId).ToListAsync();

            currentCartList.ForEach(cart =>
            {
                var tmp = cartList.FirstOrDefault(x => x.ProductId == cart.ProductId);
                if (tmp != null)
                {
                    cart.Quantity += tmp.Quantity;
                }
            });

            cartList = cartList.Where(x => !currentCartList.Any(y => y.ProductId == x.ProductId))
                .ToList();

            _cartRepository.UpdateRange(currentCartList);
            await _cartRepository.AddRangeAsync(cartList);
            await _cartRepository.SaveChangesAsync();

            return request.Id;
        }
    }
}
