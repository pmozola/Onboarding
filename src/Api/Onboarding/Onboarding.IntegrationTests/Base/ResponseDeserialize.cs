using Newtonsoft.Json;

namespace Onboarding.IntegrationTests.Base
{
    public static class ResponseDeserialize
    {
        public static HttpResponse<T> Deserialize<T>(this HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().Result;

            return new HttpResponse<T>(
                response.StatusCode,
                JsonConvert.DeserializeObject<T>(content));
        }
    }
}
