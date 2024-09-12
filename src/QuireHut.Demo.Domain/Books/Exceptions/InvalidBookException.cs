using System;

namespace QuireHut.Demo.Domain.Books.Exceptions;

public class InvalidBookException : Exception
{
    public InvalidBookException(string message) : base(message)
    {
    }
}
