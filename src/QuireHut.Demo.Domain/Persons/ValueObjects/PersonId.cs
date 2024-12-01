namespace QuireHut.Demo.Domain.Persons.ValueObjects;

public record PersonId(Guid Value)
{
    public static PersonId Empty{get;} = default;
    public static PersonId CreateNew() => new(Guid.NewGuid());
}