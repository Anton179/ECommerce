using MediatR;
using System;
using ECommerce.Core.Application.Infrastructure.Dtos.OrderDtos;

namespace ECommerce.Core.Application.Queries.Orders
{
    public class GetOrderQuery : IRequest<OrderDto>
    {
        public Guid Id { get; set; }
    }
}
