namespace Onboarding.Domain.Base
{
    public class DomainException : Exception
    {
        public DomainException(string message, OnboardingDomainErrorsCodes errorCode) : base(message) => ErrorCode = (int)errorCode;

        public int ErrorCode { get; }
    }
}
