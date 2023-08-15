using Hotel.Common.Model;
using Hotel.Core.Contract.Common;
using Hotel.Core.Contract.Persistence;

namespace Hotel.Persistence.Service;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMessageBusClient _messageBusClient;
    private readonly User _user;

    public HotelService(IHotelRepository hotelRepository, IMessageBusClient messageBusClient, IClaimPrincipalAccessor claimPrincipalAccessor)
    {
        _hotelRepository = hotelRepository;
        _messageBusClient = messageBusClient;
        _user = claimPrincipalAccessor.User;
    }
    public async Task BookHotel(int id)
    {
        var hotel = await _hotelRepository.GetHotelById(id);
        var message = new HotelPublishedDto()
        {
            Id = hotel.hotelId,            
            Event = "Hotel_Publish",
            UserId = _user?.Id ?? ""
        };
        _messageBusClient.PublishHotel(message);
    }
}
