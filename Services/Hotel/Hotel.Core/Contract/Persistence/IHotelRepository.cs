using Hotel.Common.Model;

namespace Hotel.Core.Contract.Persistence;

public interface IHotelRepository
{
    Task<IEnumerable<HotelResponse>> HotelList();
    Task<HotelResponse> GetHotelById(int hotelId);
}
