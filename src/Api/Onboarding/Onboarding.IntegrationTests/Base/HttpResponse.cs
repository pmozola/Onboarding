using System.Net;

namespace Onboarding.IntegrationTests.Base
{
    public record HttpResponse<T>(HttpStatusCode StatusCode, T Response);
}
