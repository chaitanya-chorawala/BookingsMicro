using Hotel.Core.Contract.Common;
using Hotel.Core.Contract.Persistence;
using Hotel.Persistence.Common;
using Hotel.Persistence.Configuration;
using Hotel.Persistence.Repository;
using Hotel.Persistence.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RabbitMQ.Client;

namespace Hotel.Persistence;

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
                Port = int.Parse(configuration["RabbitMQ:Port"]!),
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
            services.TryAddScoped<IHotelService, HotelService>();

            return services;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
            throw;
        }
    }
}
