namespace Library.Demo.Domain;

public class InvalidEmailException : Exception
{
    public InvalidEmailException(){}
    public InvalidEmailException(string message) : base(message){}

}
