using Onboarding.Persistence;

namespace Onboarding.IntegrationTests.TestDatabase
{
    internal static class IntegrationTestDataSeeder
    {

        public static void Seed(OnboardingDBContext dBContext)
        {
            var templates = OnboardTemplateTestData.Get();
            dBContext.ProcessTemplate.AddRange(templates);
            dBContext.SaveChanges();

            var userOnboarding = UserOnboardTemplateTestData.Create(new int[] { 1 }, templates.First());
            dBContext.UserOnboardingProcesses.AddRange(userOnboarding);
            dBContext.SaveChanges();
        }
    }
}
