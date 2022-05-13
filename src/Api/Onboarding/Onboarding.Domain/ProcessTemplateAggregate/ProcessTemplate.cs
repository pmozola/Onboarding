using Onboarding.Domain.Base;

namespace Onboarding.Domain.ProcessTemplateAggregate
{
    public class ProcessTemplate : AggregateRoot
    {
        private const int NameFieldLimit = 15;

        public string Name { get; init; } = String.Empty;

        public static ProcessTemplate Create(string name)
        {
            if (name.Length > NameFieldLimit)
            {
                throw new ProcessTemplateNameToLongDomainException(name.Length, NameFieldLimit);
            }

            return new ProcessTemplate { Name = name };
        }

        private ProcessTemplate() { }
    }
}
