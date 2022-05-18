using Onboarding.Domain.UserAggregate;

namespace Onboarding.Persistence.Repositories
{
    public class FakeUserInformationRepository : IUserInformationRepository
    {
        public Task<UserInformation[]> GetForIds(List<int> ids)
        {
            return Task.FromResult(ids.Select(x => new UserInformation { Id = x }).ToArray());
        }
    }
}
