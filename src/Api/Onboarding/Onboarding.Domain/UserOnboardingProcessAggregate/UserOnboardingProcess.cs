using Onboarding.Domain.Base;

namespace Onboarding.Domain.UserOnboardingProcessAggregate
{
    public class UserOnboardingProcess : Entity, IAggregateRoot
    {
        public int UserId { get; init; }
        public int TemplateId { get; init; }
        public IReadOnlyCollection<UserOnboardStep> UserOnboardSteps { get; init; } = new List<UserOnboardStep>();

        public static UserOnboardingProcess Create(int userId, int templateId, IEnumerable<int> stepsId)
        {
            var steps = stepsId.Select(stepId => UserOnboardStep.Create(stepId));

            return new UserOnboardingProcess { TemplateId = templateId, UserId = userId, UserOnboardSteps = steps.ToList().AsReadOnly() };
        }

        private UserOnboardingProcess()
        { }
    }

    public class UserOnboardStep : Entity
    {
        private UserOnboardStep() { }

        public static UserOnboardStep Create(int templateStepId) => new() { TemplateStepId = templateStepId };

        public int TemplateStepId { get; init; }
        public int ApprovedByUserId { get; private set; }
        public string Comment { get; private set; } = string.Empty;
        public DateTimeOffset ModifyOn { get; private set; }
        public StepStatus Status { get; private set; }

        public void Approve(int userId, string comment, IUserRoleChecker userRoleChecker, IPreviousStepChecker previousStepChecker)
        {
            if (userRoleChecker.IsInRole(1)) throw new Exception();
            if (Status == StepStatus.Approved) throw new Exception("allready approved");
            ApprovedByUserId = userId;
            Comment = comment;
            ModifyOn = DateTimeOffset.Now;
            Status = StepStatus.Approved;
        }

        public void Reject(int userId, string comment, IUserRoleChecker userRoleChecker, IPreviousStepChecker previousStepChecker)
        {
            if (userRoleChecker.IsInRole(1)) throw new Exception();
            if (Status == StepStatus.Approved) throw new Exception("allready approved");
            ApprovedByUserId = userId;
            Comment = comment;
            ModifyOn = DateTimeOffset.Now;
            Status = StepStatus.Rejected;
        }
    }

    public enum StepStatus
    { Approved = 1, Rejected }
}
