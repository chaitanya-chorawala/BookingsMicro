using Reservation.Common.Model;
namespace Reservation.Core.Contract.Persistence;

public interface IHotelRepository
{
    Task<HotelResponse> GetHotelById(int hotelId);
}
