namespace Hotel.Common.Model;

public record HotelPublishedDto
{
    public int Id { get; set; }    
    public string Event { get; set; }
    public string UserId { get; set; }
}
