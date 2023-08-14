using Reservation.Core.Contract.Common;
using Reservation.Core.Contract.Persistence;
using Reservation.Persistence.Common;
using Reservation.Persistence.Configuration;
using Reservation.Persistence.Repository;
using Reservation.Persistence.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RabbitMQ.Client;

namespace Reservation.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        try
        {
            //Add Rabbit MQ
            var factory = new ConnectionFactory()
            {
                HostName = configuration["RabbitMQ:Host"]!,                
                UserName = configuration["RabbitMQ:User"]!,
                Password = configuration["RabbitMQ:Pass"]!,
                VirtualHost = configuration["RabbitMQ:VirtualHost"]!
            };

            var _connection = factory.CreateConnection();
            var _channel = _connection.CreateModel();

            services.AddSingleton<ApplicationDbContext>();
            services.TryAddSingleton<IMessageBusClient>(new MessageBusClient(configuration, _connection, _channel));
            services.TryAddScoped<IClaimPrincipalAccessor, ClaimPrincipalAccessor>();
            services.TryAddScoped<IHotelRepository, HotelRepository>();
            services.TryAddScoped<IReservationRepository, ReservationRepository>();
            services.TryAddScoped<IReservationService, ReservationService>();

            services.TryAddSingleton<IEventProcessor, EventProcessor>();

            services.AddHostedService<MessageBusSubscriber>();

            return services;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
            throw;
        }
    }
}
