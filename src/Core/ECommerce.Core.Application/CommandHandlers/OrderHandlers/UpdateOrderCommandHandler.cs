using AutoMapper;
using ECommerce.Core.Application.Commands.OrderCommands;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Exceptions;

namespace ECommerce.Core.Application.CommandHandlers.OrderHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Order> _orderRepository;

        public UpdateOrderCommandHandler(IMapper mapper, IGenericRepository<Order> orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            if (order == null)
            {
                throw new NotFoundException("The order doesn't exist!");
            }

            var updatedOrder = _mapper.Map<Order>(request);

            order.Status = updatedOrder.Status;
            order.Address = updatedOrder.Address;
            order.Payment = updatedOrder.Payment;
            order.ShippingId = updatedOrder.ShippingId;
            order.Price = updatedOrder.Price;
            order.UpdatedDate = DateTime.UtcNow;

            _orderRepository.Update(order);
            await _orderRepository.SaveChangesAsync();

            return order.Id;
        }
    }
}
