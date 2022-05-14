using Onboarding.Domain.Base;

namespace Onboarding.Domain.UserOnboardingProcessAggregate.Specifications
{
    internal class StepIsNotApprovedYetSpecification : ISpecification<UserOnboardStep>
    {
        public Task<bool> IsSatisfiedBy(UserOnboardStep entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }
    }
}
