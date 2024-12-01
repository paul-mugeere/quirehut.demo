using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuireHut.Demo.Domain;
using QuireHut.Demo.Domain.Genres;

namespace QuireHut.Demo.Infrastructure.Persistence.EntityConfigurations;

public class GenresConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> modelBuilder)
    {
        modelBuilder.ToTable("Genres");     
        modelBuilder.HasKey(x => x.Id);
        modelBuilder.Property(x => x.Id).HasConversion(c=>c.Value, value => new(value));
     }
}
