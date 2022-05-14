using Onboarding.Domain.Base;
using Onboarding.Domain.ProcessTemplateAggregate;

namespace Onboarding.Domain.UserOnboardingProcessAggregate.Specifications
{
    public class UserIsInRoleSpecification : ISpecification<UserOnboardingProcess>
    {
        public Task<bool> IsSatisfiedBy(UserOnboardingProcess entity, CancellationToken cancellationToken = default)
        {
            // TODO implementaion
            return Task.FromResult(true);
        }
    }
}
