using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onboarding.Domain.ProcessTemplateAggregate;

namespace Onboarding.Persistence.Configuration
{
    public class StepTemplateEntityConfiguration : IEntityTypeConfiguration<StepTemplate>
    {
        public void Configure(EntityTypeBuilder<StepTemplate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(StepTemplate.StepFieldLimit);
            builder.Property(x => x.ApprovingUserRoleId).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Order).IsRequired();
        }
    }
}
