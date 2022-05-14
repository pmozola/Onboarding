namespace Onboarding.Domain.UserAggregate
{
    public interface IUserInformationRepository
    {
        public Task<UserInformation[]> GetForIds(List<int> ids);
    }
}
