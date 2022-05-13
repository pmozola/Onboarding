using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onboarding.Domain.ProcessTemplateAggregate;

namespace Onboarding.Persistence.Configuration
{
    public class StepEntityConfiguration : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(Step.StepFieldLimit);
            builder.Property(x => x.ApprovingUserRoleId).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Order).IsRequired();
        }
    }
}
