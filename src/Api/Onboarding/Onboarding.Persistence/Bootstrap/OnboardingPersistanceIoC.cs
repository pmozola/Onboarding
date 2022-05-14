using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Onboarding.Domain.Base;
using Onboarding.Domain.UserAggregate;
using Onboarding.Persistence.Repositories;

namespace Onboarding.Persistence.Bootstrap
{
    public static class OnboardingPersistanceIoC
    {
        public static IServiceCollection AddOnboardingPersistance(this IServiceCollection services)
        {
            services.AddDbContext<OnboardingDBContext>(opt => opt.UseInMemoryDatabase("onboarding"));

            services.AddScoped(typeof(IAddGenericRepository<>), typeof(EntityFrameworkGenericRepository<>));
            services.AddScoped(typeof(IGetGenericRepository<>), typeof(EntityFrameworkGenericRepository<>));
            services.AddScoped(typeof(IDeleteGenericRepository<>), typeof(EntityFrameworkGenericRepository<>));
            services.AddScoped(typeof(IUpdateGenericRepository<>), typeof(EntityFrameworkGenericRepository<>));

            services.AddScoped<IUserInformationRepository, FakeUserInformationRepository>();

            return services;
        }
    }
}
