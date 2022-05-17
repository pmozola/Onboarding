using Onboarding.Application.QueryHandlers;
using Onboarding.IntegrationTests.Base;

namespace Onboarding.IntegrationTests.ApiEnpoints
{
    public static class TemplateApi
    {
        private const string tempalteApiUrl = "/api/template/";
        public async static Task<HttpResponse<GetProcessTemplateQueryResponse>> Get(int templateId, HttpClient client)
        {
            var result = await client.GetAsync(tempalteApiUrl + templateId);

            return result.Deserialize<GetProcessTemplateQueryResponse>();
        }
    }
}
