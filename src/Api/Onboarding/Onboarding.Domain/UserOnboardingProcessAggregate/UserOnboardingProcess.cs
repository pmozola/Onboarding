using Onboarding.Domain.Base;

namespace Onboarding.Domain.UserOnboardingProcessAggregate
{
    public class UserOnboardingProcess : Entity, IAggregateRoot
    {
        public int UserId { get; init; }
        public int TemplateId { get; init; }
        public List<UserOnboardStep> UserOnboardSteps { get; set; } = new();

        public static UserOnboardingProcess Create(int userId, int templateId)
        {
            return new UserOnboardingProcess { TemplateId = templateId, UserId = userId };
        }

        private UserOnboardingProcess()
        { }
    }

    public class UserOnboardStep : Entity
    {
        public int TemplateStepId { get; init; }
        public int ApprovedBy { get; private set; }
        public string Comment { get; private set; } = string.Empty;
        public DateTimeOffset ModifyOn { get; private set; }
        public StepStatus Status { get; private set; }

        public void Approve(int userId, string comment, IUserRoleChecker userRoleChecker, IPreviousStepChecker previousStepChecker)
        {
            if (userRoleChecker.IsInRole(1)) throw new Exception();
            if (Status == StepStatus.Approved) throw new Exception("allready approved");
            if (!previousStepChecker.IsApproved()) throw new Exception("last shoud be aprovied");
            ApprovedBy = userId;
            Comment = comment;
            ModifyOn = DateTimeOffset.Now;
            Status = StepStatus.Approved;
        }
    }

    public enum StepStatus
    { Approved = 1, Rejected }
}
