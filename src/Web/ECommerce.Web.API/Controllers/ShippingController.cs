using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Queries.Shipping;
using ECommerce.Core.DataAccess.Dtos.ShippingDtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Web.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShippingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<ShippingDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllShippingsQuery(), cancellationToken);

            return Ok(result);
        }
    }
}
