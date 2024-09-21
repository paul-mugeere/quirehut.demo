using QuireHut.Demo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;
using System.Text.Json.Serialization;
using QuireHut.Demo.Infrastructure.Persistence.Helpers;


namespace QuireHut.Demo.Infrastructure;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(book => book.Id);

        builder.Property(book => book.Id)
        .HasConversion(c => c.Value, value => new(value));

        builder.Property(book => book.Title)
        .HasConversion(c => c.Value, value => new(value));

        builder.Property(book => book.Subject)
        .HasConversion(c => c.Value, value => new(value));

        builder.OwnsMany(book => book.Editions, editionsBuilder =>
        {
            editionsBuilder.ToTable("Editions");
            editionsBuilder.HasKey(k => k.Id);
            editionsBuilder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => new(value));
            editionsBuilder.Property(p => p.ISBN)
            .HasConversion(c => c.Value, value => new(value));
            editionsBuilder.WithOwner().HasForeignKey(key => key.BookId);
            
            editionsBuilder.Property<List<GenreId>>("_genreIds")
            .HasConversion(new JsonValueConverter<List<GenreId>>()
            ).HasColumnName("genres").HasColumnType("jsonb").IsRequired(false);

            editionsBuilder.Property<List<AuthorId>>("_authorIds")
            .HasConversion(new JsonValueConverter<List<AuthorId>>()
            ).HasColumnName("authors").HasColumnType("jsonb").IsRequired(false);

            editionsBuilder.Property(p=>p.Publisher)
                .HasConversion(new JsonValueConverter<Publisher>()).HasColumnType("jsonb").IsRequired(false);

            editionsBuilder.Property(p => p.Dimensions)
            .HasConversion(new JsonValueConverter<Dimensions>()).HasColumnType("jsonb").IsRequired(false);
            
        });

    }
}
