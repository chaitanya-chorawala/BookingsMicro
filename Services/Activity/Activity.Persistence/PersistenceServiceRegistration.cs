using Activity.Core.Contract.Common;
using Activity.Core.Contract.Persistence;
using Activity.Persistence.Common;
using Activity.Persistence.Configuration;
using Activity.Persistence.Repository;
using Activity.Persistence.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Activity.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddSingleton<ApplicationDbContext>();
        services.TryAddScoped<IClaimPrincipalAccessor, ClaimPrincipalAccessor>();
        services.TryAddScoped<IActivityRepository, ActivityRepository>();

        services.AddScoped<IActivityService, ActivityService>();
        services.AddHttpClient<IActivityService, ActivityService>();

        return services;
    }
}
