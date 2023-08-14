using Reservation.Common.Model;

namespace Reservation.Core.Contract.Common;

public interface IMessageBusClient
{
    void PublishReservation(ReservationPublishedDto reservationPublishedDto);
}
