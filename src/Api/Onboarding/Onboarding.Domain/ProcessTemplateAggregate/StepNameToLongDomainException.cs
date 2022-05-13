using Onboarding.Domain.Base;

namespace Onboarding.Domain.ProcessTemplateAggregate
{
    public class StepNameToLongDomainException : DomainException
    {
        public StepNameToLongDomainException(int usedCharCount, int limitOfChar) 
            : base($"Step name can be maximum {limitOfChar} number of char, but was {usedCharCount}.",
                  ErrorsCodeEnum.ProcessTemplateNameToLong)
        {
        }
    }
}
