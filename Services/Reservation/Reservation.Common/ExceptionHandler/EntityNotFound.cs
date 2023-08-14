namespace Reservation.Common.ExceptionHandler;

public class EntityNotFound : NotFoundException
{
    public EntityNotFound(string msg) : base(msg)
    {}
}
