﻿namespace Reservation.Common.ExceptionHandler;

public class EntityBadRequest : NotFoundException
{
    public EntityBadRequest(string msg) : base(msg)
    {
    }
}
