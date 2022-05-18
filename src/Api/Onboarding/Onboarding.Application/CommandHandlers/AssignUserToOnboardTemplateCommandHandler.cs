using MediatR;
using Onboarding.Domain.Base;
using Onboarding.Domain.ProcessTemplateAggregate;
using Onboarding.Domain.UserOnboardingProcessAggregate;

namespace Onboarding.Application.CommandHandlers
{
    public class AssignUserToOnboardTemplateCommandHandler : IRequestHandler<AssignUserToOnboardTemplateCommand, AssignUserToOnboardTemplateResponse>
    {
        private readonly IGetGenericRepository<ProcessTemplate> templateRepository;
        private readonly IAddGenericRepository<UserOnboardingProcess> userOnboardingRepository;

        public AssignUserToOnboardTemplateCommandHandler(
            IGetGenericRepository<ProcessTemplate> templateRepository,
            IAddGenericRepository<UserOnboardingProcess> userOnboardingRepository)
        {
            this.templateRepository = templateRepository;
            this.userOnboardingRepository = userOnboardingRepository;
        }

        public async Task<AssignUserToOnboardTemplateResponse> Handle(AssignUserToOnboardTemplateCommand request, CancellationToken cancellationToken)
        {
            var template = await this.templateRepository.Get(request.TemplateId, cancellationToken);
            if (template == null) throw new NotFoundException(nameof(ProcessTemplate), request.TemplateId);

            var userOnboard = UserOnboardingProcess.Create(request.UserId, template.Id, template.Steps.Select(x => x.Id));

            var id = await userOnboardingRepository.Add(userOnboard, cancellationToken);

            return new AssignUserToOnboardTemplateResponse(id);
        }
    }

    public record AssignUserToOnboardTemplateCommand(int TemplateId, int UserId) : IRequest<AssignUserToOnboardTemplateResponse>;

    public record AssignUserToOnboardTemplateResponse(int UserOnboardId);
}
