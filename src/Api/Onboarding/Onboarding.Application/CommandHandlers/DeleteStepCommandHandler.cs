using MediatR;

namespace Onboarding.Application.CommandHandlers
{
    public class DeleteLastStepCommandHandler : AsyncRequestHandler<DeleteLastStepCommand>
    {
        protected override Task Handle(DeleteLastStepCommand request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }

    public record DeleteLastStepCommand(int TemplateId) : IRequest;
}
