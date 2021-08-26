using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Queries.Categories;
using ECommerce.Core.DataAccess.Dtos.CategoryDtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("main")]
        public async Task<ActionResult<CategoryWithImageDto>> GetMainCategories(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetMainCategoriesQuery(), cancellationToken);

            return Ok(result);
        }
    }
}
