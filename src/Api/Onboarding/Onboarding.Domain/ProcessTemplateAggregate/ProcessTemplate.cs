using Onboarding.Domain.Base;

namespace Onboarding.Domain.ProcessTemplateAggregate
{
    public class ProcessTemplate : AggregateRoot
    {
        public string Name { get; init; } = String.Empty;

        public static ProcessTemplate Create(string name)
        {
            return new ProcessTemplate { Name = name };
        }

        private ProcessTemplate() { }
    }
}
