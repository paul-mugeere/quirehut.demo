using Library.Demo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Demo.Infrastructure;

public class LibraryDemoDbContext : DbContext
{
    public LibraryDemoDbContext(DbContextOptions<LibraryDemoDbContext> options) : base(options)
    {
    }

    public DbSet<Person> People => Set<Person>();
    public DbSet<Address> Addresses => Set<Address>();
}
