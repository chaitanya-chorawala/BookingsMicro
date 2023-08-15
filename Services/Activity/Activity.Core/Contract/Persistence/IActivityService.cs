namespace Activity.Core.Contract.Persistence;

public interface IActivityService
{
    Task BookActivity(int id);
}
