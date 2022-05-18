using Onboarding.Domain.Base;

namespace Onboarding.Domain.UserOnboardingProcessAggregate
{
    public class UserIsNotInRoleException : DomainException
    {
        public UserIsNotInRoleException(int userId)
            : base($"User {userId} is not in correct role to approve step",
                  OnboardingDomainErrorsCodes.UserIsNotInRole)
        {
        }
    }
}
