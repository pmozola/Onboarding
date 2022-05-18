using Onboarding.Domain.Base;

namespace Onboarding.Domain.UserOnboardingProcessAggregate.Specifications
{
    public class UserIsInRoleSpecification : ISpecification<UserOnboardingProcess>
    {
        public Task<bool> IsSatisfiedBy(UserOnboardingProcess entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }
    }
}
