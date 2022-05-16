using Onboarding.Domain.Base;

namespace Onboarding.Domain.ProcessTemplateAggregate
{
    public class StepTemplate : Entity
    {
        public const int StepFieldLimit = 255;
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public int ApprovingUserRoleId { get; init; }
        public int Order { get; init; }
        public int ProcessTemplateId { get; init; }
        
        private StepTemplate() { }

        public static StepTemplate Create(string name, string description, int approvingUserRole, int order)
        {
            if (StepFieldLimit < name.Length)
            {
                throw new StepNameToLongDomainException(name.Length, StepFieldLimit);
            }

            return new StepTemplate { Name = name, Description = description, ApprovingUserRoleId = approvingUserRole, Order = order };
        }
    }
}
