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
    private static IConnection _connection;
    private static IModel _channel;

    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        try
        {
            var retryCount = 0;
            var maxRetryAttempts = 10;
            var retryDelaySeconds = 20;
            while (retryCount < maxRetryAttempts)
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

                    _connection = factory.CreateConnection();
                    _channel = _connection.CreateModel();                    
                    break; // Exit the retry loop on successful connection
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to connect to RabbitMQ: {ex.Message}");
                    Console.WriteLine($"Retrying in {retryDelaySeconds} seconds...");
                    retryCount++;
                    System.Threading.Thread.Sleep(retryDelaySeconds * 1000);
                }
            }
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
