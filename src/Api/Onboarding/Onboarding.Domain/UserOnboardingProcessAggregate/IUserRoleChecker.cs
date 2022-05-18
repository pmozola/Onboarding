namespace Onboarding.Domain.UserOnboardingProcessAggregate
{
    public interface IUserRoleChecker
    {
        public bool IsInRole(int roleId);
    }
}