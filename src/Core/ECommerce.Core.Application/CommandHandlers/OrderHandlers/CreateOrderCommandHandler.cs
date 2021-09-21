using AutoMapper;
using ECommerce.Core.Application.Commands.OrderCommands;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Enums;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Dtos.OrderDtos;
using ECommerce.Core.Application.Infrastructure.Interfaces;

namespace ECommerce.Core.Application.CommandHandlers.OrderHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderProducts> _orderProductsRepository;
        private readonly IGenericRepository<CartItem> _cartRepository;

        public CreateOrderCommandHandler(IMapper mapper, ICurrentUserProvider currentUserProvider,
            IGenericRepository<Order> orderRepository, IGenericRepository<OrderProducts> orderProductsRepository,
            IGenericRepository<CartItem> cartRepository)
        {
            _mapper = mapper;
            _currentUserProvider = currentUserProvider;
            _orderRepository = orderRepository;
            _orderProductsRepository = orderProductsRepository;
            _cartRepository = cartRepository;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var userId = _currentUserProvider.GetUserId();

            var orderProductsDtos = _mapper.Map<ICollection<OrderProductForCreateDto>>(request.OrderProducts);
            var orderProducts = _mapper.Map<ICollection<OrderProducts>>(orderProductsDtos);

            var carts = _cartRepository.Read().Where(c => c.UserId == userId);

            var order = new Order()
            {
                ShippingId = request.Shipping.Id,
                Price = orderProducts.Sum(p => p.Price * p.Quantity) + request.Shipping.Price,
                UserId = userId,
                Status = OrderStatus.Pending,
                Payment = request.Payment,
                OrderProducts = orderProducts,
                Address = request.Address,
            };

            await _orderRepository.AddAsync(order);
            await _orderProductsRepository.AddRangeAsync(orderProducts);
            _cartRepository.DeleteRange(carts);

            await _orderRepository.SaveChangesAsync();
            await _orderProductsRepository.SaveChangesAsync();
            await _cartRepository.SaveChangesAsync();

            return order.Id;
        }
    }
}
