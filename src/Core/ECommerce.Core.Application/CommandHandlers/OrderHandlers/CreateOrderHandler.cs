﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.Application.Commands.OrderCommands;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Enums;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Core.Application.CommandHandlers.OrderHandlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderProducts> _orderProductsRepository;
        private readonly IGenericRepository<Cart> _cartRepository;

        public CreateOrderHandler(IMapper mapper, ICurrentUserProvider currentUserProvider,
            IGenericRepository<Order> orderRepository, IGenericRepository<OrderProducts> orderProductsRepository,
            IGenericRepository<Cart> cartRepository)
        {
            _mapper = mapper;
            _currentUserProvider = currentUserProvider;
            _orderRepository = orderRepository;
            _orderProductsRepository = orderProductsRepository;
            _cartRepository = cartRepository;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserProvider.GetUserId();

            var carts = await _cartRepository.Read().Where(c => c.UserId == userId).ToListAsync(cancellationToken);

            var orderProducts = _mapper.Map<ICollection<OrderProducts>>(carts);

            var order = new Order()
            {
                ShippingId = request.Shipping.Id,
                DeliveryPrice = request.Shipping.Price,
                UserId = userId,
                Status = OrderStatus.Pending,
                Payment = request.Payment,
                OrderProducts = orderProducts,
                Address = request.Address
            };

            await _orderRepository.AddAsync(order, cancellationToken);
            await _orderProductsRepository.AddRangeAsync(orderProducts, cancellationToken);

            await _orderRepository.SaveChangesAsync();
            await _orderProductsRepository.SaveChangesAsync();

            return order.Id;
        }
    }
}