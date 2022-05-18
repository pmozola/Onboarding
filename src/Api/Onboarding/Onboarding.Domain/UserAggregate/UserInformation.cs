using Onboarding.Domain.Base;

namespace Onboarding.Domain.UserAggregate
{
    public class UserInformation : Entity, IAggregateRoot
    {
        public string FullName { get; init; } = "Stefan Burczymucha";
    }
}
