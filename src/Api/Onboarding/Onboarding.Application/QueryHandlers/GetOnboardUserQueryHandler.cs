using MediatR;
using Onboarding.Domain.Base;
using Onboarding.Domain.ProcessTemplateAggregate;
using Onboarding.Domain.UserAggregate;
using Onboarding.Domain.UserOnboardingProcessAggregate;

namespace Onboarding.Application.QueryHandlers
{
    public class GetOnboardUserQueryHandler : IRequestHandler<GetOnboardUserQuery, GetOnboardUserResponse>
    {
        private readonly IGetGenericRepository<ProcessTemplate> processTemplateRepository;
        private readonly IGetGenericRepository<UserOnboardingProcess> userOnboardingProcessRepository;
        private readonly IUserInformationRepository userRepository;

        public GetOnboardUserQueryHandler(
            IGetGenericRepository<ProcessTemplate> processTemplateRepository,
            IGetGenericRepository<UserOnboardingProcess> userOnboardingProcessRepository,
            IUserInformationRepository userRepository)
        {
            this.processTemplateRepository = processTemplateRepository;
            this.userOnboardingProcessRepository = userOnboardingProcessRepository;
            this.userRepository = userRepository;
        }

        public async Task<GetOnboardUserResponse> Handle(GetOnboardUserQuery request, CancellationToken cancellationToken)
        {
            var process = await userOnboardingProcessRepository.Get(request.ProcessId, cancellationToken);
            if (process == null) throw new NotFoundException(nameof(UserOnboardingProcess), request.ProcessId);

            var template = await processTemplateRepository.Get(process.TemplateId, cancellationToken);
            if (template == null) throw new NotFoundException(nameof(ProcessTemplate), process.TemplateId);

            var approvedUsers = await this.userRepository.GetForIds(process.UserOnboardSteps.Select(x => x.ApprovedByUserId).ToList());

            var steps = template.Steps.Select(step =>
            {
                var onboardStep = process.UserOnboardSteps.First(x => x.TemplateStepId == step.Id);

                return new Step(
                    UserOnboardStep: onboardStep.Id,
                    Name: step.Name,
                    Description: step.Description,
                    Order: step.Order,
                    Status: onboardStep.Status,
                    ApprovedBy: approvedUsers.First(x => x.Id == onboardStep.ApprovedByUserId).FullName,
                    ModifyOn: onboardStep.ModifyOn,
                    Comment: onboardStep.Comment);
            });

            return new GetOnboardUserResponse(
                Template: new Template(template.Name, template.Id),
                Steps: steps.ToList());
        }
    }

    public record GetOnboardUserQuery(int ProcessId) : IRequest<GetOnboardUserResponse>;
    public record GetOnboardUserResponse(Template Template, List<Step> Steps);
    public record Template(string Name, int Id);
    public record Step(int UserOnboardStep, string Name, string Description, int Order, StepStatus Status, string ApprovedBy, DateTimeOffset ModifyOn, string Comment);
}
