using ECommerce.Core.Application.Commands.UploadCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ECommerce.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UploadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadImage([FromQuery] string imageId)
        {
            var result = _mediator.Send(new UploadImageCommand() { FormCollection = await Request.ReadFormAsync(), ImageId = imageId });

            return Ok(result);
        }
    }
}
