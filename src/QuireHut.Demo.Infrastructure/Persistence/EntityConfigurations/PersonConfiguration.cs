using QuireHut.Demo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuireHut.Demo.Infrastructure;

// public class PersonConfiguration : IEntityTypeConfiguration<Person>
// {
//     public void Configure(EntityTypeBuilder<Person> modelBuilder)
//     {
//         modelBuilder.ToTable("persons");

//         modelBuilder
//         .HasKey(person => person.Id);

//         modelBuilder
//         .Property(person => person.Id)
//         .HasConversion(id => id.Value, value => new(value));

//         modelBuilder
//         .Property(person => person.Email)
//         .HasConversion(id => id.Value, value => new(value));

//         modelBuilder.HasMany(person => person.Addresses).WithOne(x=>x.Person).HasForeignKey(x=>x.PersonId);
//     }
// }
