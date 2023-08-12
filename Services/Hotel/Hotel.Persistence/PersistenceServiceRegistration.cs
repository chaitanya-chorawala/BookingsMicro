using Hotel.Core.Contract.Common;
using Hotel.Core.Contract.Persistence;
using Hotel.Persistence.Common;
using Hotel.Persistence.Configuration;
using Hotel.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Hotel.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddSingleton<ApplicationDbContext>();
        services.TryAddScoped<IClaimPrincipalAccessor, ClaimPrincipalAccessor>();
        services.TryAddScoped<IHotelRepository, HotelRepository>();

        return services;
    }
}
