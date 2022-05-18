using Onboarding.Domain.ProcessTemplateAggregate;
using Onboarding.Domain.UserOnboardingProcessAggregate;

namespace Onboarding.IntegrationTests.TestDatabase
{
    public static class OnboardTemplateTestData
    {
        public static ProcessTemplate[] Get()
        {
            var firstTemplate = ProcessTemplate.Create("HR Employee Template");
            firstTemplate.AddStep("HR", "Go to HR department", 1);
            firstTemplate.AddStep("IT", "Go to IT department", 1);
            firstTemplate.AddStep("Workflow department", "Go to Workflow department", 1);

            return new ProcessTemplate[] { firstTemplate };
        }
    }

    public static class UserOnboardTemplateTestData
    {
        public static UserOnboardingProcess[] Create(int[] userIds, ProcessTemplate template)
        {
            return
                userIds.Select(userId =>
                UserOnboardingProcess.Create(userId, template.Id, template.Steps.Select(x => x.Id).ToList()))
                .ToArray();
        }
    }
}
