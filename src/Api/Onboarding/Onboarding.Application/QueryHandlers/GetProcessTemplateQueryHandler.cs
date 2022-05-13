using MediatR;

namespace Onboarding.Application.QueryHandlers
{
    public class GetProcessTemplateQueryHandler : IRequestHandler<GetProcessTemplateQuery, GetProcessTemplateQueryResponse>
    {
        public Task<GetProcessTemplateQueryResponse> Handle(GetProcessTemplateQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetProcessTemplateQueryResponse(request.Id, "New fake name"));
        }
    }

    public record GetProcessTemplateQuery(int Id) : IRequest<GetProcessTemplateQueryResponse>;
    public record GetProcessTemplateQueryResponse(int Id, string Name);
}
