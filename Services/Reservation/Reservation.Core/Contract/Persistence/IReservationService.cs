namespace Reservation.Core.Contract.Persistence;

public interface IReservationService
{
    Task BookHotel(int hotelid, string userId);
    Task BookActivity(int activityid);
}
