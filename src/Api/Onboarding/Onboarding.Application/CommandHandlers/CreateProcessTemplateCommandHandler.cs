using MediatR;
using Onboarding.Domain.ProcessTemplateAggregate;

namespace Onboarding.Application.CommandHandlers
{
    public class CreateProcessTemplateCommandHandler : IRequestHandler<CreateProcessTemplateCommand, CreateProcessTemplateResponse>
    {
        public Task<CreateProcessTemplateResponse> Handle(CreateProcessTemplateCommand request, CancellationToken cancellationToken)
        {
            var entity = ProcessTemplate.Create(request.Name);

            return Task.FromResult(new CreateProcessTemplateResponse(123, entity.Name));
        }
    }

    public record CreateProcessTemplateCommand(string Name) : IRequest<CreateProcessTemplateResponse>;
    public record CreateProcessTemplateResponse(int Id, string Name);
}
