using QuireHut.Demo.Domain.Persons.ValueObjects;

namespace QuireHut.Demo.Domain.Persons.Repositories;

public interface IPersonRepository
{
    Task<Person> GetPersonAsync(PersonId personId);
    Task<IEnumerable<Person>> GetPersonsAsync(IEnumerable<PersonId> personIds);
}