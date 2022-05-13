using MediatR;
using Onboarding.Domain.Base;
using Onboarding.Domain.ProcessTemplateAggregate;

namespace Onboarding.Application.QueryHandlers
{
    public class GetProcessTemplateQueryHandler : IRequestHandler<GetProcessTemplateQuery, GetProcessTemplateQueryResponse>
    {
        private readonly IGetGenericRepository<ProcessTemplate> repository;

        public GetProcessTemplateQueryHandler(IGetGenericRepository<ProcessTemplate> repository)
        {
            this.repository = repository;
        }
        public async Task<GetProcessTemplateQueryResponse> Handle(GetProcessTemplateQuery request, CancellationToken cancellationToken)
        {
            var template = await repository.Get(request.Id, cancellationToken);

            if (template == null) throw new NotFoundException(nameof(ProcessTemplate), request.Id);

            return new GetProcessTemplateQueryResponse(template.Id, template.Name);
        }
    }

    public record GetProcessTemplateQuery(int Id) : IRequest<GetProcessTemplateQueryResponse>;
    public record GetProcessTemplateQueryResponse(int Id, string Name);
}
