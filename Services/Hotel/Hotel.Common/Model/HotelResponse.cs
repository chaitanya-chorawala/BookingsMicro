namespace Hotel.Common.Model;

public record HotelResponse
{
    public int hotelId { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string zip_code { get; set; }
    public string phone_number { get; set; }
    public string website { get; set; }
}
