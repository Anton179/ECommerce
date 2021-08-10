using AutoMapper;
using ECommerce.Core.Application.Commands.ProductCommands;
using ECommerce.Core.DataAccess.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;


        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }
    }
}
