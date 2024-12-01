﻿using Microsoft.EntityFrameworkCore;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Persons;

namespace QuireHut.Demo.Infrastructure.Persistence;

public class LibraryDemoDbContext : DbContext
{
    public LibraryDemoDbContext(DbContextOptions<LibraryDemoDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDemoDbContext).Assembly);
    }
    
    public DbSet<Book> Books { get; init; }
    public DbSet<Person> Persons { get; init; }
}
