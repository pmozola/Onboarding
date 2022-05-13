using Microsoft.EntityFrameworkCore;
using Onboarding.Domain.ProcessTemplateAggregate;

namespace Onboarding.Persistence
{
    public class OnboardingDBContext : DbContext
    {
        public OnboardingDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProcessTemplate> ProcessTemplate { get; set; } = default!;
        public DbSet<Step> Step { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OnboardingDBContext).Assembly);
        }
    }
}
