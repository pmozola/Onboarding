using Onboarding.Domain.ProcessTemplateAggregate;
using Onboarding.Domain.UserOnboardingProcessAggregate;

namespace Onboarding.Persistence.TestData
{
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
