 using Onboarding.Domain.Base;

namespace Onboarding.Domain.ProcessTemplateAggregate
{
    public class Step : Entity
    {
        public const int StepFieldLimit = 15;
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public int ApprovingUserRoleId { get; init; }
        public int Order { get; init; }

        private Step() { }

        public static Step Create(string name, string description, int approvingUserRole, int order)
        {
            if (StepFieldLimit < name.Length)
            {
                throw new StepNameToLongDomainException(name.Length, StepFieldLimit);
            }

            return new Step { Name = name, Description = description, ApprovingUserRoleId = approvingUserRole, Order = order };
        }
    }
}
