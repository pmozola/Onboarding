using MediatR;
using Onboarding.Domain.Base;
using Onboarding.Domain.ProcessTemplateAggregate;

namespace Onboarding.Application.CommandHandlers
{
    public class DeleteLastStepCommandHandler : AsyncRequestHandler<DeleteLastStepCommand>
    {
        private readonly Domain.Base.IUpdateGenericRepository<ProcessTemplate> repository;

        public DeleteLastStepCommandHandler(IUpdateGenericRepository<ProcessTemplate> repository)
        {
            this.repository = repository;
        }

        protected override async Task Handle(DeleteLastStepCommand request, CancellationToken cancellationToken)
        {
            var template = await repository.Get(request.TemplateId, cancellationToken);

            if (template == null) throw new NotFoundException(nameof(ProcessTemplate), request.TemplateId);

            template.RemoveLastStep();

            await repository.Update(template, cancellationToken);
        }
    }

    public record DeleteLastStepCommand(int TemplateId) : IRequest;
}
