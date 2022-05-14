using Microsoft.EntityFrameworkCore;
using Onboarding.Domain.ProcessTemplateAggregate;
using Onboarding.Domain.UserOnboardingProcessAggregate;

namespace Onboarding.Persistence
{
    public class OnboardingDBContext : DbContext
    {
        public OnboardingDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProcessTemplate> ProcessTemplate { get; set; } = default!;
        public DbSet<StepTemplate> StepTemplate { get; set; } = default!;
        public DbSet<UserOnboardingProcess> UserOnboardingProcesses { get; set; } = default!;
        public DbSet<UserOnboardStep> UserOnboardSteps { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OnboardingDBContext).Assembly);
        }
    }
}
