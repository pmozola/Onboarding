using MediatR;
using Onboarding.Domain.Base;
using Onboarding.Domain.ProcessTemplateAggregate;

namespace Onboarding.Application.CommandHandlers
{
    public class CreateStepCommandHandler : IRequestHandler<CreateStepCommand, CreateStepCommandResponse>
    {
        private readonly IUpdateGenericRepository<ProcessTemplate> repository;

        public CreateStepCommandHandler(IUpdateGenericRepository<ProcessTemplate> repository)
        {
            this.repository = repository;
        }

        public async Task<CreateStepCommandResponse> Handle(CreateStepCommand request, CancellationToken cancellationToken)
        {
            var template = await repository.Get(request.TemplateId, cancellationToken);

            if (template == null) throw new NotFoundException(nameof(ProcessTemplate), request.TemplateId);

            template.AddStep(request.Name, request.Description, request.ApprovingUserRole);

            await repository.Update(template, cancellationToken);

            return new CreateStepCommandResponse(template.Steps.First(x => x.Name == request.Name).Id, request.Name);
        }
    }

    public record CreateStepCommand(int TemplateId, string Name, string Description, int ApprovingUserRole) : IRequest<CreateStepCommandResponse>;
    public record CreateStepCommandResponse(int Id, string Name);
}
