using QuireHut.Demo.Domain.Persons.ValueObjects;

namespace QuireHut.Demo.Domain.Persons;

public class Person{

    public PersonId Id { get;  } =PersonId.Empty;
    public Fullname Fullname { get; }

    private Person(){}

    private Person(PersonId id, string firstname, string lastname)
    {
        Id = id;
        Fullname = new Fullname(firstname, lastname);
    }
    public static Person CreateNew(string firstname,string lastname)
    {
        return new(PersonId.CreateNew(), firstname, lastname);
    }
}