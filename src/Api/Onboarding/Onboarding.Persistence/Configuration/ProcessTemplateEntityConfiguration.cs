using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onboarding.Domain.ProcessTemplateAggregate;

namespace Onboarding.Persistence.Configuration
{
    public class ProcessTemplateEntityConfiguration : IEntityTypeConfiguration<ProcessTemplate>
    {
        public void Configure(EntityTypeBuilder<ProcessTemplate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(ProcessTemplate.NameFieldLimit);
            builder.HasMany(x => x.Steps);
        }
    }
}
