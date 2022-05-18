using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Onboarding.IntegrationTests.TestDatabase;
using Onboarding.Persistence;

namespace Onboarding.IntegrationTests.Base
{
    public class OnboardingWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.Single(
                         d => d.ServiceType ==
                             typeof(DbContextOptions<OnboardingDBContext>));

                services.Remove(descriptor);

                services.AddDbContext<OnboardingDBContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDatabase");
                });

                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<OnboardingDBContext>();


                    db.Database.EnsureCreated();

                    IntegrationTestDataSeeder.Seed(db);
                }
            });
        }
    }
}
