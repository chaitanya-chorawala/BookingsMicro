using Hotel.Common.Model;
using Hotel.Core.Contract.Common;
using Hotel.Core.Contract.Persistence;

namespace Hotel.Persistence.Service;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMessageBusClient _messageBusClient;

    public HotelService(IHotelRepository hotelRepository, IMessageBusClient messageBusClient)
    {
        _hotelRepository = hotelRepository;
        _messageBusClient = messageBusClient;
    }
    public async Task BookHotel(int id)
    {
        var hotel = await _hotelRepository.GetHotelById(id);
        var message = new HotelPublishedDto()
        {
            Id = hotel.hotelId,
            Name = hotel.name,
            Event = "Hotel_Publish"
        };
        _messageBusClient.PublishHotel(message);
    }
}
