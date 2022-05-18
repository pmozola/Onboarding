using System.Net;

using FluentAssertions;
using Onboarding.IntegrationTests.ApiEnpoints;
using Onboarding.IntegrationTests.Base;
using Xunit;

namespace Onboarding.IntegrationTests
{
    public class TemplateTests : IClassFixture<OnboardingWebApplicationFactory>
    {
        private readonly HttpClient client;

        public TemplateTests(OnboardingWebApplicationFactory factory)
        {
            client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnTemplate()
        {
            var result = await TemplateApi.Get(1, client);

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Response.Should().NotBeNull();
        }

        [Fact]
        public async Task Get_NotExistingIdReturn404()
        {
            var result = await TemplateApi.Get(999, client);

            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
