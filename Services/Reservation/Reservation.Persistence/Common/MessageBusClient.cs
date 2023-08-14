using Reservation.Common.Model;
using Reservation.Core.Contract.Common;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Reservation.Persistence.Common;

public class MessageBusClient : IMessageBusClient, IDisposable
{
    private readonly IConfiguration _configuration;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public MessageBusClient(IConfiguration configuration, IConnection connection, IModel model)
    {
        _configuration = configuration;
        

        try
        {
            _connection = connection;
            _channel = model;            
            _channel.ExchangeDeclare(exchange: "reservation", type: ExchangeType.Fanout);
            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutDown;

            Console.WriteLine("--> Connected to MessageBus");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> Could not connect to the Message Bus: {ex.Message}");
            throw;
        }
    }

    private void RabbitMQ_ConnectionShutDown(object? sender, ShutdownEventArgs e)
    {
        Console.WriteLine("--> RabbitMQ Connection Shutdown");
    }

    public void PublishReservation(ReservationPublishedDto reservationPublishedDto)
    {
        var message = JsonSerializer.Serialize(reservationPublishedDto);
        if (!_connection.IsOpen)
            Console.WriteLine("--> RabbitMQ connection is closed, not sending");

        Console.WriteLine("--> RabbitMQ Connection Open, sending message...");
        SendMessage(message);
    }

    private void SendMessage(string message)
    { 
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(exchange: "reservation",
            routingKey: "",
            basicProperties: null,
            body: body);

        Console.WriteLine($"--> We have sent {message}");
    }

    public void Dispose()
    {
        Console.WriteLine("MessageBus Disposed");
        if (_channel.IsOpen)
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
