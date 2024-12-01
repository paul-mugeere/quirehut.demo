using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuireHut.Demo.Domain.Persons;
using QuireHut.Demo.Domain.Persons.ValueObjects;

namespace QuireHut.Demo.Infrastructure.Persistence.EntityConfigurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> modelBuilder)
    {
        modelBuilder.ToTable("persons");

        modelBuilder
        .HasKey(person => person.Id);

        modelBuilder
        .Property(person => person.Id)
        .HasConversion(id => id.Value, value => new(value));
        
        modelBuilder.Property(person =>person.Fullname)
            .HasConversion(x=>x.ToString(),value=>Fullname.FromString(value));

    }
}
