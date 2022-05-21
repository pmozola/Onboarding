using Microsoft.Toolkit.Mvvm.Input;
using Onboarding.Employee.App.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;

namespace Onboarding.Employee.App.ViewModel
{
    public partial class UserOnboardTemplateViewModel : BaseViewModel
    {

        private readonly UserTemplateService userTemplateService;

        public ObservableCollection<Step> UserTemplateSteps { get; } = new();
        public UserOnboardTemplateViewModel(UserTemplateService userTemplateService)
        {
            Title = "User Onboarding abc";
            this.userTemplateService = userTemplateService;
        }

       [ICommand]
       public async Task GetTemplate()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var template = await this.userTemplateService.GetUserTemplate();

                if (template != null)
                {
                    UserTemplateSteps.Clear();
                    template.Steps.ForEach(step => UserTemplateSteps.Add(step));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }

    public class StatusStepToStatusImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (StepStatus)value;

            return status switch
            {
                StepStatus.Approved => @"ok.svg",
                StepStatus.Rejected => @"rejected.svg",
                _ => @"info.svg",
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
