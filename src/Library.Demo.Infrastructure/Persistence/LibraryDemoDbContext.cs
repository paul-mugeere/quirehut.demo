using Library.Demo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Demo.Infrastructure;

public class LibraryDemoDbContext : DbContext
{
    public LibraryDemoDbContext(DbContextOptions<LibraryDemoDbContext> options) : base(options)
    {
    }

    // public DbSet<Person> People => Set<Person>();
    // public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<BookItem> BookItems=> Set<BookItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDemoDbContext).Assembly);
    }
}
