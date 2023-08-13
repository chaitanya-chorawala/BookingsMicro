namespace Hotel.Core.Contract.Persistence;

public interface IHotelService
{
    Task BookHotel(int id);
}
