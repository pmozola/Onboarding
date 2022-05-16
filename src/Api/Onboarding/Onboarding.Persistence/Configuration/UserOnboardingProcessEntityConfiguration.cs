using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onboarding.Domain.UserOnboardingProcessAggregate;

namespace Onboarding.Persistence.Configuration
{
    public class UserOnboardingProcessEntityConfiguration : IEntityTypeConfiguration<UserOnboardingProcess>
    {
        public void Configure(EntityTypeBuilder<UserOnboardingProcess> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.UserOnboardSteps);
            builder.Navigation(x => x.UserOnboardSteps).AutoInclude();
        }
    }
}
