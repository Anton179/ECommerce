using ECommerce.Core.Application.Commands.CartCommands;
using ECommerce.Core.DataAccess.Dtos.CartDtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Queries.CartQueries;
using ECommerce.Infrastructure.API.Attributes;

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

        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<Guid>> AddToCart([FromBody] CreateCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("getCart")]
        public async Task<ActionResult<IEnumerable<CartDto>>> GetCart(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CartQuery(), cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("getCount")]
        public async Task<ActionResult<int>> GetNumberOfProductsInCart(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new NumberOfProductsInCartQuery(), cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [HttpDelete("removeAll")]
        public async Task<ActionResult> RemoveAllByCurrentUser(CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteAllCartCommand(), cancellationToken);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("remove/{productId}")]
        [ApiExceptionFilter]
        public async Task<ActionResult> RemoveByCurrentUser([FromRoute] Guid productId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteCartCommand() { ProductId = productId }, cancellationToken);

            return Ok(result);
        }
    }
}
