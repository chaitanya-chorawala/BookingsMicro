namespace Reservation.Common.Model;

public record ReservationResponse
{
    public int reservationId { get; set; }
    public string check_in_date { get; set; }
    public string check_out_date { get; set; }
    public ReservationStatus status { get; set; }
    public ReservationType type { get; set; }
    public string userId { get; set; }
}
