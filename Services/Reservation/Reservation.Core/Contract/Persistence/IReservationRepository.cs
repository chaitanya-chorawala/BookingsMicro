using Reservation.Common.Model;

namespace Reservation.Core.Contract.Persistence;

public interface IReservationRepository
{
    Task<GenericResponseWithPaging<IEnumerable<ReservationResponse>?>> ReservationList(int pageIndex, int pageSize);
    Task<ReservationResponse> GetReservationById(int reservationId);
    Task<ReservationResponse> AddReservation(AddReservation model);
}
