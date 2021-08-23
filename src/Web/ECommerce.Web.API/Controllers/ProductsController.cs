using ECommerce.Core.Application.Commands.ProductCommands;
using ECommerce.Core.Application.Queries.Products;
using ECommerce.Core.DataAccess.Dtos.ProductDtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "vendor")]
        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<ActionResult<ProductDto>> GetProducts(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllProductsQuery(), cancellationToken);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductQuery() { Id = id }, cancellationToken);

            return Ok(result);
        }
    }
}
