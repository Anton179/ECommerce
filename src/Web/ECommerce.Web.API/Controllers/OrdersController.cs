using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Commands.OrderCommands;
using ECommerce.Core.Application.Queries.Orders;
using ECommerce.Core.DataAccess.Dtos.OrderDtos;
using ECommerce.Infrastructure.API.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "user")]
        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        [Authorize(Roles = "user")]
        [HttpGet("get/{id}")]
        [ApiExceptionFilter]
        public async Task<ActionResult<OrderDto>> GetOrder([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetOrderQuery() {Id = id}, cancellationToken);

            return Ok(result);
        }
    }
}
