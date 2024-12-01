namespace QuireHut.Demo.Domain.Common.Exceptions;

public class InvalidEmailException : Exception
{
    public InvalidEmailException(){}
    public InvalidEmailException(string message) : base(message){}

}
