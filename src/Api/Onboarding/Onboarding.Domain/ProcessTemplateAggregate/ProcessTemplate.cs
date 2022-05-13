using Onboarding.Domain.Base;

namespace Onboarding.Domain.ProcessTemplateAggregate
{
    public class ProcessTemplate : Entity, IAggregateRoot
    {
        private const int NameFieldLimit = 15;
        public string Name { get; init; } = string.Empty;
        public List<Step> Steps = new();

        public static ProcessTemplate Create(string name)
        {
            if (name.Length > NameFieldLimit)
            {
                throw new ProcessTemplateNameToLongDomainException(name.Length, NameFieldLimit);
            }

            return new ProcessTemplate { Name = name };
        }

        private ProcessTemplate() { }

        public void AddStep(string name, string description, int approvingUserRole)
        {
            var orderNumber = Steps.Select(x => x.Order).LastOrDefault();

            Steps.Add(Step.Create(name, description, approvingUserRole, orderNumber));
        }

        public void RemoveLastStep()
        {
            var step = Steps.LastOrDefault();

            if (step != null)
            {
                Steps.Remove(step);
            }
        }
    }
}
