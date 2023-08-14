namespace Reservation.Core.Contract.Common;

public interface IEventProcessor
{
    Task ProcessEvent(string msg);
}
