using Activity.Common.Model;

namespace Activity.Core.Contract.Persistence;

public interface IActivityRepository
{
    Task<IEnumerable<ActivityResponse>> ActivityList();
    Task<ActivityResponse> GetActivityById(int activityId);
}
