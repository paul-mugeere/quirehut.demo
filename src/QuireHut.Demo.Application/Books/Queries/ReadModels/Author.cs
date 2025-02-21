using QuireHut.Demo.Domain.Persons;

namespace QuireHut.Demo.Application.Books.Queries.ReadModels;

public record Author(Guid Id, string Fullname)
{
    public static Author? From(Person? person) => person==null? null : new(person.Id.Value, person.Fullname.ToString());
};