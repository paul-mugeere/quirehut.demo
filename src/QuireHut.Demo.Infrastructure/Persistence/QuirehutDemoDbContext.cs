using Microsoft.EntityFrameworkCore;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Persons;

namespace QuireHut.Demo.Infrastructure.Persistence;

public class QuirehutDemoDbContext(DbContextOptions<QuirehutDemoDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuirehutDemoDbContext).Assembly);
    }
    
    public DbSet<Book> Books { get; init; }
    public DbSet<Person> Persons { get; init; }
}
