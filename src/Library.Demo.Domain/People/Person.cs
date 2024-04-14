namespace Library.Demo.Domain;

public readonly record struct PersonId(Guid Value){
    public static PersonId Empty { get; } = default;
}

public class Person{
    public PersonId Id { get; protected set; } = PersonId.Empty;
    public string? FirstName { get; protected set; }
    public string? LastName { get; protected set; }
    public string? Email { get; protected set;}
    public string? Phone { get; protected set;}
    public Address? Address { get; protected set; }
}
