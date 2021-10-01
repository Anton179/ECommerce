using ECommerce.Core.Application.Commands.ProductCommands;
using ECommerce.Core.Application.Queries.Products;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Authorization;
using ECommerce.Core.Application.Infrastructure.Dtos.ProductDtos;

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

        [Authorize(Roles = Roles.Vendor)]
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [Authorize(Roles = Roles.Vendor)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> UpdateProduct(UpdateProductCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductForDisplayDto>>> GetProducts([FromQuery] GetProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductQuery() { Id = id }, cancellationToken);

            return Ok(result);
        }

        [Authorize(Roles = Roles.Vendor)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> DeleteProductById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteProductCommand() { Id = id });

            return Ok(result);
        }

        [Authorize]
        [HttpGet("getOrderedProducts")]
        public async Task<ActionResult<PaginatedResult<ProductForDisplayDto>>> GetOrderedProducts([FromQuery] GetOrderedProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }
    }
}
