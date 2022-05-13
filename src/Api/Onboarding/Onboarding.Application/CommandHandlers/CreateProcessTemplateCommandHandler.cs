using MediatR;
using Onboarding.Domain.Base;
using Onboarding.Domain.ProcessTemplateAggregate;

namespace Onboarding.Application.CommandHandlers
{
    public class CreateProcessTemplateCommandHandler : IRequestHandler<CreateProcessTemplateCommand, CreateProcessTemplateResponse>
    {
        private readonly ICreateGenericRepository<ProcessTemplate> repository;

        public CreateProcessTemplateCommandHandler(ICreateGenericRepository<ProcessTemplate> repository)
        {
            this.repository = repository;
        }

        public async Task<CreateProcessTemplateResponse> Handle(CreateProcessTemplateCommand request, CancellationToken cancellationToken)
        {
            var entity = ProcessTemplate.Create(request.Name);

            await repository.Create(entity, cancellationToken);

            return new CreateProcessTemplateResponse(entity.Id, entity.Name);
        }
    }

    public record CreateProcessTemplateCommand(string Name) : IRequest<CreateProcessTemplateResponse>;
    public record CreateProcessTemplateResponse(int Id, string Name);
}
