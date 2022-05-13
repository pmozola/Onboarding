using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onboarding.Application.CommandHandlers;

namespace Onboarding.API.Controllers
{
    [Route("api/template/{templateId}/[controller]")]
    [ApiController]
    public class StepController : ControllerBase
    {
        private readonly ISender mediator;

        public StepController(ISender mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost()]
        [ProducesResponseType(typeof(CreateStepCommandResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(int templateId, string name, string description, int approvingUserRole)
        {
            var result = await mediator.Send(new CreateStepCommand(templateId, name, description, approvingUserRole));

            return CreatedAtAction(nameof(TemplateController.Get), new { id = templateId }, result);
        }

        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int templateId)
        {
            await mediator.Send(new DeleteLastStepCommand(templateId));

            return Ok();
        }
    }
}
