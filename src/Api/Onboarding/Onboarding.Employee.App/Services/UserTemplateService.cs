using System.Globalization;
using System.Net.Http.Json;

namespace Onboarding.Employee.App.Services
{

    public class UserTemplateService
    {
        private readonly HttpClient httpClient;

        public UserTemplateService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<UserTemplate> GetUserTemplate()
        {
            var response = await httpClient.GetAsync("http://10.0.2.2:5270/api/OnboardUser?onboardProcessUserId=1"); // Hardcoded template.

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<UserTemplate>();

                return result;
            }

            return null;
        }
    }



    public record UserTemplate(Template Template, List<Step> Steps);
    public record Template(string Name, int Id);
    public record Step(int UserOnboardStep, string Name, string Description, int Order, StepStatus Status, string ApprovedBy, DateTimeOffset ModifyOn, string Comment);

    public enum StepStatus
    { Approved = 1, Rejected }


    
}
