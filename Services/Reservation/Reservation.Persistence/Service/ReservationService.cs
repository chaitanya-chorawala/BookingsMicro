using Reservation.Common.Model;
using Reservation.Core.Contract.Common;
using Reservation.Core.Contract.Persistence;

namespace Reservation.Persistence.Service;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IHotelRepository _hotelRepository;    
    private readonly User _user;

    public ReservationService(IReservationRepository reservationRepository
        , IHotelRepository hotelRepository        
        , IClaimPrincipalAccessor claimPrincipalAccessor)
    {
        _reservationRepository = reservationRepository;
        _hotelRepository = hotelRepository;        
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
                status = ReservationStatus.SUCCESS,
                type = ReservationType.ACTIVITY
            };
            var reservation = await _reservationRepository.AddReservation(reserv);            
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
                status = ReservationStatus.SUCCESS,
                type = ReservationType.HOTEL
            };
            var reservation = await _reservationRepository.AddReservation(reserv);            
        }
        catch (Exception ex)
        {
            throw;
        }
    }    
}
