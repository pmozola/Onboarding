using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onboarding.Application.CommandHandlers;
using Onboarding.Application.QueryHandlers;

namespace Onboarding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly ISender mediator;

        public TemplateController(ISender mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateProcessTemplateResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(string name)
        {
            var result = await this.mediator.Send(new CreateProcessTemplateCommand(name));

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(GetProcessTemplateQueryResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await mediator.Send(new GetProcessTemplateQuery(id));

            return Ok(result);
        }
    }
}
