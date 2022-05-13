namespace Onboarding.Domain.Base
{
    public class NotFoundException : DomainException
    {
        public NotFoundException(string entityName, int id)
            : base($"{entityName} with id {id} cannot be found.", OnboardingDomainErrorsCodes.NotFound) 
        { }
    }
}
