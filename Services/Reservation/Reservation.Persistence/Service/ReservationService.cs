using Reservation.Common.Model;
using Reservation.Core.Contract.Common;
using Reservation.Core.Contract.Persistence;

namespace Reservation.Persistence.Service;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IHotelRepository _hotelRepository;
    private readonly IMessageBusClient _messageBusClient;
    private readonly User _user;

    public ReservationService(IReservationRepository reservationRepository
        , IHotelRepository hotelRepository
        , IMessageBusClient messageBusClient
        , IClaimPrincipalAccessor claimPrincipalAccessor)
    {
        _reservationRepository = reservationRepository;
        _hotelRepository = hotelRepository;
        _messageBusClient = messageBusClient;
        _user = claimPrincipalAccessor.User;
    }
    public async Task BookActivity(int activityid, string name)
    {
        try
        {
            AddReservation reserv = new AddReservation()
            {
                Id = activityid,
                userId = _user?.Id ?? "",
                check_in_date = DateOnly.FromDateTime(DateTime.Now),
                check_out_date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                status = ReservationStatus.PENDING,
                type = ReservationType.ACTIVITY
            };
            var reservation = await _reservationRepository.AddReservation(reserv);
            DoPayment(reservation.reservationId, name, "Activity_Reservation");
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task BookHotel(int hotelid, string name)
    {
        try
        {
            AddReservation reserv = new AddReservation()
            {
                Id = hotelid,
                userId = _user?.Id ?? "",
                check_in_date = DateOnly.FromDateTime(DateTime.Now),
                check_out_date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                status = ReservationStatus.PENDING,
                type = ReservationType.HOTEL
            };
            var reservation = await _reservationRepository.AddReservation(reserv);
            DoPayment(reservation.reservationId, name, "Hotel_Reservation");
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    
    private void DoPayment(int reservationId, string name, string eventName)
    {
        var message = new ReservationPublishedDto()
        {
            Id = reservationId,
            Name = name,
            Event = eventName
        };
        _messageBusClient.PublishReservation(message);
    }
}
