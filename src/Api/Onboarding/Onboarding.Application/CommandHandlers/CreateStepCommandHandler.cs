using MediatR;

namespace Onboarding.Application.CommandHandlers
{
    public class CreateStepCommandHandler : IRequestHandler<CreateStepCommand, CreateStepCommandResponse>
    {
        public Task<CreateStepCommandResponse> Handle(CreateStepCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CreateStepCommandResponse(1, "some Name"));
        }
    }

    public record CreateStepCommand(int TemplateId, string Name, string Description, int ApprovingUserRole) : IRequest<CreateStepCommandResponse>;


    public record CreateStepCommandResponse(int Id, string Name);
}
