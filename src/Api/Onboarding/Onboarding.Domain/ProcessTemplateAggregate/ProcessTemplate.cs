using Onboarding.Domain.Base;

namespace Onboarding.Domain.ProcessTemplateAggregate
{
    public class ProcessTemplate : Entity, IAggregateRoot
    {
        public const int NameFieldLimit = 255;
        public string Name { get; init; } = string.Empty;
        public List<StepTemplate> Steps = new();

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
            if (Steps.Any(x => x.Name == name)) throw new StepNameMustBeUniqueInTemplateDomainException();

            var orderNumber = Steps.Select(x => x.Order).LastOrDefault() + 1;

            Steps.Add(StepTemplate.Create(name, description, approvingUserRole, orderNumber));
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
