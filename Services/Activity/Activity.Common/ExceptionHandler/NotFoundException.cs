﻿namespace Activity.Common.ExceptionHandler;

public abstract class NotFoundException : Exception
{
    public NotFoundException(string msg) : base(msg)
    {}
}
