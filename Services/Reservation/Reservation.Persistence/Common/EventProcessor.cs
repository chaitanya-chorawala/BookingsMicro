using Microsoft.Extensions.DependencyInjection;
using Reservation.Common.Model;
using Reservation.Core.Contract.Common;
using Reservation.Core.Contract.Persistence;
using System.Text.Json;

namespace Reservation.Persistence.Common;

public class EventProcessor : IEventProcessor
{
    private readonly IServiceScopeFactory _scopeFactory;

    public EventProcessor(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }
    public async Task ProcessEvent(string msg)
    {
        var eventType = DetermineEvent(msg);
        switch(eventType)
        {
            case ReservationEvent.Hotel_Publish:
                await ReserveHotel(msg);
                break;
            default:
                break;
        }

    }

    private ReservationEvent DetermineEvent(string msg)
    {
        Console.WriteLine("--> Determining Event");
        var eventType = JsonSerializer.Deserialize<GenericEventDto>(msg);
        switch (eventType?.Event ?? "")
        {
            case "Hotel_Publish":
                Console.WriteLine("--> Hotel publish event detacted.");
                return ReservationEvent.Hotel_Publish;
            default:
                Console.WriteLine("--> Could not determine the event type.");
                return ReservationEvent.Undetermine;
        }
    }

    private async Task ReserveHotel(string reservationPublishedMsg)
    {
        try
        {
            using var scope = _scopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IReservationService>();
            var reservationPublishedDto = JsonSerializer.Deserialize<ReservationPublishedDto>(reservationPublishedMsg);
            await service.BookHotel(reservationPublishedDto!.Id, reservationPublishedDto!.Name);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
