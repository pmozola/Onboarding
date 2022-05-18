using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onboarding.Domain.UserOnboardingProcessAggregate;

namespace Onboarding.Persistence.Configuration
{
    public class UserOnboardStepEntityConfiguration : IEntityTypeConfiguration<UserOnboardStep>
    {
        public void Configure(EntityTypeBuilder<UserOnboardStep> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TemplateStepId).IsRequired();
        }
    }
}
