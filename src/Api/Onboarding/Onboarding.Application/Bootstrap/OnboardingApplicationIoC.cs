using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Onboarding.Application.CommandHandlers;

namespace Onboarding.Application.Bootstrap
{
    public static class OnboardingApplicationIoC
    {
        public static IServiceCollection AddOnboardingApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateProcessTemplateCommandHandler).Assembly);
            return services;
        }
    }
}
