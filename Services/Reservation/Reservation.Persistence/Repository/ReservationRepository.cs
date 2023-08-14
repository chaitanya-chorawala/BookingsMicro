using Dapper;
using Reservation.Common.Model;
using Reservation.Common.ExceptionHandler;
using Reservation.Core.Contract.Persistence;
using Reservation.Persistence.Configuration;
using System.Data;

namespace Reservation.Persistence.Repository;

public class ReservationRepository : IReservationRepository
{
    private readonly ApplicationDbContext _context;

    public ReservationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ReservationResponse> AddReservation(AddReservation model)
    {
        try
        {
            using IDbConnection conn = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("id", model.Id, DbType.Int32, ParameterDirection.Input);                 
            parameters.Add("check_in_date", model.check_in_date.ToString(), DbType.String, ParameterDirection.Input);                 
            parameters.Add("check_out_date", model.check_out_date.ToString(), DbType.String, ParameterDirection.Input);                 
            parameters.Add("status", model.status, DbType.Int32, ParameterDirection.Input);                 
            parameters.Add("type", model.type, DbType.Int32, ParameterDirection.Input);                 
            parameters.Add("userId", model.userId, DbType.String, ParameterDirection.Input);
            
            var reservation = await conn.QueryFirstOrDefaultAsync<ReservationResponse>(
                "ReservationAdd",
                param: parameters,
                commandType: CommandType.StoredProcedure);

            return reservation;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<ReservationResponse> GetReservationById(int reservationId)
    {
        try
        {
            using IDbConnection conn = _context.CreateConnection();
            var parameters = new { reservationId = reservationId };
            var reservation = await conn.QueryFirstOrDefaultAsync<ReservationResponse>(
                "ReservationGetById",
                param: parameters,
                commandType: CommandType.StoredProcedure);

            if (reservation is null)
                throw new EntityNotFound($"Reservation with id: {reservationId} not found!");

            return reservation;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<IEnumerable<ReservationResponse>> ReservationList()
    {
        try
        {
            using IDbConnection conn = _context.CreateConnection();
            var reservationList = await conn.QueryAsync<ReservationResponse>("ReservationGet", commandType: CommandType.StoredProcedure);
            return reservationList;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
