using Onboarding.Domain.ProcessTemplateAggregate;

namespace Onboarding.Persistence.TestData
{
    public static class OnboardTemplateTestData
    {
        public static ProcessTemplate[] Get()
        {
            var firstTemplate = ProcessTemplate.Create("HR Employee Template");
            firstTemplate.AddStep("HR", "Go to HR department", 1);
            firstTemplate.AddStep("IT", "Go to IT department", 1);
            firstTemplate.AddStep("Workflow department", "Go to Workflow department", 1);

            var secondTemplate = ProcessTemplate.Create("IT Employee Template");
            secondTemplate.AddStep("IT", "Go to IT department", 1);
            secondTemplate.AddStep("HR", "Go to HR department", 1);

            return new ProcessTemplate[] { firstTemplate, secondTemplate };
        }
    }
}
