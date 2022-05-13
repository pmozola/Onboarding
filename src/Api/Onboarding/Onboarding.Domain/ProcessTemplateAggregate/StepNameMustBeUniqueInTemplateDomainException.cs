using Onboarding.Domain.Base;

namespace Onboarding.Domain.ProcessTemplateAggregate
{
    public class StepNameMustBeUniqueInTemplateDomainException : DomainException
    {
        public StepNameMustBeUniqueInTemplateDomainException() 
            : base($"Step name must be unique in template.",
                  OnboardingDomainErrorsCodes.StepNameMustBeUniqueInTemplate)
        {
        }
    }
}
