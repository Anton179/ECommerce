using System;
using ECommerce.Core.DataAccess.Dtos.OrderDtos;
using MediatR;
using System.Collections.Generic;

namespace ECommerce.Core.Application.Queries.Orders
{
    public class GetOrderQuery : IRequest<OrderDto>
    {
        public Guid Id { get; set; }
    }
}
