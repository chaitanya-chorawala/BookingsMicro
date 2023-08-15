namespace Reservation.Common.Model;

public record ReservationPublishedDto
{
    public int Id { get; set; }    
    public string Event { get; set; }
    public string UserId { get; set; }
}
