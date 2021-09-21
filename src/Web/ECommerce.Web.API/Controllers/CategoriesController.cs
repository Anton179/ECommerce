using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Core.Application.Infrastructure.Dtos.CategoryDtos;
using ECommerce.Core.Application.Queries.Categories;

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
