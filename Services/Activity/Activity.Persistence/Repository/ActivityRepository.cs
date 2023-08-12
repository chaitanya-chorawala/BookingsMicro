using Dapper;
using Activity.Common.Model;
using Activity.Common.ExceptionHandler;
using Activity.Core.Contract.Persistence;
using Activity.Persistence.Configuration;
using System.Data;

namespace Activity.Persistence.Repository;

public class ActivityRepository : IActivityRepository
{
    private readonly ApplicationDbContext _context;

    public ActivityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ActivityResponse> GetActivityById(int activityId)
    {
        try
        {
            using IDbConnection conn = _context.CreateConnection();
            var parameters = new { activityId = activityId };
            var Activity = await conn.QueryFirstOrDefaultAsync<ActivityResponse>(
                "ActivityGetById",
                param: parameters,
                commandType: CommandType.StoredProcedure);

            if (Activity is null)
                throw new EntityNotFound($"Activity with id: {activityId} not found!");

            return Activity;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<IEnumerable<ActivityResponse>> ActivityList()
    {
        try
        {
            using IDbConnection conn = _context.CreateConnection();
            var activityList = await conn.QueryAsync<ActivityResponse>("ActivityGet", commandType: CommandType.StoredProcedure);
            return activityList;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
