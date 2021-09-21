using ECommerce.Core.DataAccess.Models.PagedRequestModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Commands.OrderCommands;
using ECommerce.Core.Application.Infrastructure.Dtos.OrderDtos;
using ECommerce.Core.Application.Queries.Orders;
using ECommerce.Web.API.Infrastructure.Authorization;

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

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateOrder([FromBody] UpdateOrderCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [Authorize(Roles = Roles.User)]
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] CreateOrderCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [Authorize(Roles = Roles.User)]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetOrderQuery() { Id = id }, cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<OrderDto>>> GetOrders([FromQuery] PagedRequest pagedRequest,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetOrdersQuery() { PagedRequest = pagedRequest }, cancellationToken);

            return Ok(result);
        }
    }
}
