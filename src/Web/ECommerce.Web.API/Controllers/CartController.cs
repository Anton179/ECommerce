using ECommerce.Core.Application.Commands.CartCommands;
using ECommerce.Core.Application.Queries.CartQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Authorization;
using ECommerce.Core.Application.Infrastructure.Dtos.CartItemDtos;

namespace ECommerce.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = Roles.User)]
        [HttpPost]
        public async Task<ActionResult<Guid>> AddCartItem([FromBody] CreateCartItemCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [Authorize(Roles = Roles.User)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetCart(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCartItemsQuery(), cancellationToken);

            return Ok(result);
        }

        [Authorize(Roles = Roles.User)]
        [HttpGet("getCount")]
        public async Task<ActionResult<int>> GetNumberOfProductsInCart(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetNumberOfProductsInCartItemsQuery(), cancellationToken);

            return Ok(result);
        }

        [Authorize(Roles = Roles.User)]
        [HttpDelete]
        public async Task<ActionResult> RemoveAllByCurrentUser()
        {
            await _mediator.Send(new DeleteAllCartItemsCommand());

            return NoContent();
        }

        [Authorize(Roles = Roles.User)]
        [HttpDelete("{productId}")]
        public async Task<ActionResult<Guid>> RemoveByProductId([FromRoute] Guid productId)
        {
            var result = await _mediator.Send(new DeleteCartItemCommand() { ProductId = productId });

            return Ok(result);
        }

        [Authorize(Roles = Roles.User)]
        [HttpPost("reorder/{id}")]
        public async Task<ActionResult<Guid>> AddProductsByOrderId([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new CreateCartItemsFromOrderCommand() { Id = id });

            return Ok(result);
        }
    }
}
