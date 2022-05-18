using Onboarding.Domain.Base;

namespace Onboarding.Domain.UserOnboardingProcessAggregate
{
    public class StepIsAlreadyApprovedException : DomainException
    {
        public StepIsAlreadyApprovedException(int userId)
            : base($"Step for user {userId} is allready approved.",
                  OnboardingDomainErrorsCodes.StepIsAllreadyApproved)
        {
        }
    }
}
