using Onboarding.Domain.Base;

namespace Onboarding.Domain.ProcessTemplateAggregate
{
    public class ProcessTemplateNameToLongDomainException : DomainException
    {
        public ProcessTemplateNameToLongDomainException(int usedCharCount, int limitOfChar) 
            : base($"Template name can be maximum {limitOfChar} number of char, but was {usedCharCount}.",
                  ErrorsCodeEnum.ProcessTemplateNameToLong)
        {
        }
    }
}
