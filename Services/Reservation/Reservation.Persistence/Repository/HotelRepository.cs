using Dapper;
using Reservation.Common.Model;
using Reservation.Common.ExceptionHandler;
using Reservation.Core.Contract.Persistence;
using Reservation.Persistence.Configuration;
using System.Data;

namespace Reservation.Persistence.Repository;

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
}
