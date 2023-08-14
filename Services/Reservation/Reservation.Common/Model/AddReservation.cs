namespace Reservation.Common.Model;

public record AddReservation
{    
    public int Id { get; set; }
    public DateOnly check_in_date { get; set; }
    public DateOnly check_out_date { get; set; }
    public ReservationStatus status { get; set; }
    public ReservationType type { get; set; }
    public string userId { get; set; }    
}
