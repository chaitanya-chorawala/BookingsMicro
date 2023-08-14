using Reservation.Common.Model;

namespace Reservation.Core.Contract.Persistence;

public interface IReservationRepository
{
    Task<IEnumerable<ReservationResponse>> ReservationList();
    Task<ReservationResponse> GetReservationById(int reservationId);
    Task<ReservationResponse> AddReservation(AddReservation model);
}
