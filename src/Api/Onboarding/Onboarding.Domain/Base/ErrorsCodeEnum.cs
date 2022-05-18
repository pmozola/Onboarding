namespace Onboarding.Domain.Base
{
    public enum OnboardingDomainErrorsCodes
    {
        ProcessTemplateNameToLong = 1,
        NotFound = 2,
        StepNameMustBeUniqueInTemplate = 3,
        UserIsNotInRole = 4,
        StepIsAllreadyApproved = 5,
    }
}
