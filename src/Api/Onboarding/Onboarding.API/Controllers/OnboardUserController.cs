using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onboarding.Application.CommandHandlers;
using Onboarding.Application.QueryHandlers;

namespace Onboarding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnboardUserController : ControllerBase
    {
        private readonly ISender mediator;

        public OnboardUserController(ISender mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost()]
        [ProducesResponseType(typeof(AssignUserToOnboardTemplateResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(int userId, int templateId)
        {
            var result = await mediator.Send(new AssignUserToOnboardTemplateCommand(templateId, userId));

            return CreatedAtAction(nameof(Get), new { templateId, userId }, result);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(GetOnboardUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int onboardProcessUserId)
        {
            var result = await mediator.Send(new GetOnboardUserQuery(onboardProcessUserId));

            return Ok(result);
        }
    }
}
