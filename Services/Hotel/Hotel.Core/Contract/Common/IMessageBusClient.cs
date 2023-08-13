using Hotel.Common.Model;

namespace Hotel.Core.Contract.Common;

public interface IMessageBusClient
{
    void PublishHotel(HotelPublishedDto hotelPublishedDto);
}
