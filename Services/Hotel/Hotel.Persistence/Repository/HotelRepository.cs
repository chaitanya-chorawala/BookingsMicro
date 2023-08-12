using Dapper;
using Hotel.Common.Model;
using Hotel.Common.ExceptionHandler;
using Hotel.Core.Contract.Persistence;
using Hotel.Persistence.Configuration;
using System.Data;

namespace Hotel.Persistence.Repository;

public class HotelRepository : IHotelRepository
{
    private readonly ApplicationDbContext _context;

    public HotelRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<HotelResponse> GetHotelById(int hotelId)
    {
        try
        {
            using IDbConnection conn = _context.CreateConnection();
            var parameters = new { hotelId = hotelId };
            var hotel = await conn.QueryFirstOrDefaultAsync<HotelResponse>(
                "HotelGetById",
                param: parameters,
                commandType: CommandType.StoredProcedure);

            if (hotel is null)
                throw new EntityNotFound($"Hotel with id: {hotelId} not found!");

            return hotel;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<IEnumerable<HotelResponse>> HotelList()
    {
        try
        {
            using IDbConnection conn = _context.CreateConnection();
            var hotelList = await conn.QueryAsync<HotelResponse>("HotelGet", commandType: CommandType.StoredProcedure);
            return hotelList;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
