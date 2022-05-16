using Microsoft.Extensions.DependencyInjection;

namespace Onboarding.Persistence.TestData
{
    internal class TestDataSeederService
    {
        private readonly OnboardingDBContext dBContext;

        public TestDataSeederService(OnboardingDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public void Seed()
        {
            dBContext.ProcessTemplate.AddRangeAsync(OnboardTemplateTestData.Get());

            dBContext.SaveChanges();
        }
    }

    public static class TestDataSeeder
    {
        public static IServiceProvider SeedTestData(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<TestDataSeederService>().Seed();
            }

            return services;
        }
    }
 

}
