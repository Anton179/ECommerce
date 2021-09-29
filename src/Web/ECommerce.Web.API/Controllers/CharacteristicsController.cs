using ECommerce.Core.Application.Infrastructure.Dtos.CharacteristicsDtos;
using ECommerce.Core.Application.Queries.Characteristics;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacteristicsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CharacteristicsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<CharacteristicDto>>> GetCharacteristicsByCategoryId([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCharacteristicsByCategoryIdQuery() { CategoryId = id }, cancellationToken);

            return Ok(result);
        }
    }
}
