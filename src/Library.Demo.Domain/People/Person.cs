namespace Library.Demo.Domain;

public class Person{
    public string? Name { get; protected set; }
    public string? Email { get; protected set;}
    public string? Phone { get; protected set;}
    public Address? Address { get; protected set; }
}
