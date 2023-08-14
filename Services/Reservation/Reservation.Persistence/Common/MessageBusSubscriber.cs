using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Reservation.Core.Contract.Common;
using System.Text;
using System.Threading.Channels;

namespace Reservation.Persistence.Common;

public class MessageBusSubscriber : BackgroundService
{
    private readonly IConfiguration _configuration;
    private readonly IEventProcessor _eventProcessor;
    private IConnection _connection;
    private IModel _channel;
    private string _queueName;

    public MessageBusSubscriber(
        IConfiguration configuration,
        IEventProcessor eventProcessor)
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
        if (_connection == null)
        {
            Console.WriteLine("Failed to establish connection to RabbitMQ after multiple attempts.");
        }
        else
        {
            _configuration = configuration;
            _eventProcessor = eventProcessor;

            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName,
                exchange: "trigger",
                routingKey: "");


            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutDown;

            Console.WriteLine("--> Connected to MessageBus");
        }
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += (ModuleHandle, ea) => {
            Console.WriteLine("--> Event Received!");

            var body = ea.Body;
            var notificationMessage = Encoding.UTF8.GetString(body.ToArray());

            _eventProcessor.ProcessEvent(notificationMessage);
        };

        _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
        return Task.CompletedTask;
    }

    private void RabbitMQ_ConnectionShutDown(object? sender, ShutdownEventArgs e)
    {
        Console.WriteLine("--> RabbitMQ Connection Shutdown");
    }
}
