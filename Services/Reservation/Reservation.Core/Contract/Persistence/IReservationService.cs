namespace Reservation.Core.Contract.Persistence;

public interface IReservationService
{
    Task BookHotel(int hotelid, string name);
    Task BookActivity(int activityid, string name);
}
