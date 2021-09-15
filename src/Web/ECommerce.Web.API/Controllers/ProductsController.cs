﻿using ECommerce.Core.Application.Commands.ProductCommands;
using ECommerce.Core.Application.Queries.Products;
using ECommerce.Core.DataAccess.Dtos.ProductDtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.DataAccess.Models.PagedRequestModels;
using ECommerce.Infrastructure.API.Attributes;

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


            return CreatedAtAction(nameof(GetProductById), new { id = result }, request);
        }

        [Authorize(Roles = "vendor")]
        [HttpPut("update/{id}")]
        [ApiExceptionFilter]
        public async Task<ActionResult<Guid>> UpdateProduct(UpdateProductCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductForDisplayDto>>> GetProducts([FromQuery]GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ApiExceptionFilter]
        public async Task<ActionResult<ProductDto>> GetProductById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductQuery() { Id = id }, cancellationToken);

            return Ok(result);
        }

        [Authorize(Roles = "vendor")]
        [HttpDelete("delete/{id}")]
        [ApiExceptionFilter]
        public async Task<ActionResult<Guid>> DeleteProductById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteProductCommand() { Id = id });

            return Ok(result);
        }
    }
}
