using Microsoft.EntityFrameworkCore;
using QuireHut.Demo.Domain.Persons;
using QuireHut.Demo.Domain.Persons.Repositories;
using QuireHut.Demo.Domain.Persons.ValueObjects;

namespace QuireHut.Demo.Infrastructure.Persistence.Repositories;

public class PersonRepository:IPersonRepository
{
    private readonly IDbContextFactory<QuirehutDemoDbContext> _dbContextFactory;

    public PersonRepository(IDbContextFactory<QuirehutDemoDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public Task<Person> GetPersonAsync(PersonId personId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Person>> GetPersonsAsync(IEnumerable<PersonId> personIds)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);
        return await context.Persons.Where(x=>personIds.Contains(x.Id)).ToListAsync().ConfigureAwait(false);
    }
}