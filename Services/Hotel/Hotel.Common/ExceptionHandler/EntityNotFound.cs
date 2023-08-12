namespace Hotel.Common.ExceptionHandler;

public class EntityNotFound : NotFoundException
{
    public EntityNotFound(string msg) : base(msg)
    {}
}
