using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Onboarding.Domain.Base;
using Onboarding.Persistence.Repositories;

namespace Onboarding.Persistence.Bootstrap
{
    public static class OnboardingPersistanceIoC
    {
        public static IServiceCollection AddOnboardingPersistance(this IServiceCollection services)
        {
            services.AddDbContext<OnboardingDBContext>(opt => opt.UseInMemoryDatabase("onboarding"));

            services.AddScoped(typeof(ICreateGenericRepository<>), typeof(EntityFrameworkGenericRepository<>));
            services.AddScoped(typeof(IGetGenericRepository<>), typeof(EntityFrameworkGenericRepository<>));
            services.AddScoped(typeof(IDeleteGenericRepository<>), typeof(EntityFrameworkGenericRepository<>));
            services.AddScoped(typeof(IUpdateGenericRepository<>), typeof(EntityFrameworkGenericRepository<>));

            return services;
        }
    }
}
