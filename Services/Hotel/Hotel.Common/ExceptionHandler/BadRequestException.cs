﻿namespace Hotel.Common.ExceptionHandler;

public abstract class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {}
}
