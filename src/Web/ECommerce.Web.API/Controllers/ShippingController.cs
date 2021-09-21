using ECommerce.Core.Application.Queries.Shipping;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Dtos.ShippingMethodDtos;

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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShippingMethodDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllShippingMethodsQuery(), cancellationToken);

            return Ok(result);
        }
    }
}
