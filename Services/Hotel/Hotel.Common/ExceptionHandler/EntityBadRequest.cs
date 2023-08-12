namespace Hotel.Common.ExceptionHandler;

public class EntityBadRequest : NotFoundException
{
    public EntityBadRequest(string msg) : base(msg)
    {
    }
}
