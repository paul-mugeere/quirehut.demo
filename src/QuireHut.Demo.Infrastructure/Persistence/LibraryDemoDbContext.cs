using QuireHut.Demo.Domain;
using Microsoft.EntityFrameworkCore;

namespace QuireHut.Demo.Infrastructure;

public class LibraryDemoDbContext : DbContext
{
    public LibraryDemoDbContext(DbContextOptions<LibraryDemoDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDemoDbContext).Assembly);
    }
}
