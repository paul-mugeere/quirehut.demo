using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.ValueObjects;
using QuireHut.Demo.Infrastructure.Persistence.Helpers;

namespace QuireHut.Demo.Infrastructure.Persistence.EntityConfigurations;

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

        builder.Property(book => book.Description)
        .HasConversion(c => c.Value, value => new(value));
        
        builder.OwnsMany(book => book.Genres, bookGenres =>
        {
            bookGenres.ToTable("BookGenres");
            bookGenres.HasKey(x => x.Id);
            bookGenres.WithOwner().HasForeignKey(key => key.BookId);
            bookGenres.HasOne(g=>g.Genre)
                .WithMany()
                .HasForeignKey(key=>key.GenreId);
        });
        builder.OwnsMany(book => book.Editions, editionsBuilder =>
        {
            editionsBuilder.ToTable("Editions");
            editionsBuilder.HasKey(k => k.Id);
            editionsBuilder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => new(value));
            editionsBuilder.Property(p => p.ISBN)
            .HasConversion(c => c.Value, value => new(value));
            editionsBuilder.WithOwner().HasForeignKey(key => key.BookId);
            
            editionsBuilder.Property(p=>p.Publisher)
                .HasConversion(new JsonValueConverter<Publisher>()).HasColumnType("jsonb").IsRequired(false);

            editionsBuilder.Property(p => p.Dimensions)
            .HasConversion(new JsonValueConverter<Dimensions>()).HasColumnType("jsonb").IsRequired(false);
        });
        builder.OwnsMany(authors => authors.Authors, authorsBuilder =>
        {
            authorsBuilder.ToTable("Authors");
            authorsBuilder.HasKey(author => author.Id);
            authorsBuilder.Property(p=>p.Id)
                .HasConversion(c=>c.Value, value=>new(value));
            authorsBuilder.WithOwner().HasForeignKey(key => key.BookId);
            authorsBuilder.HasOne(person => person.Person)
                .WithMany().HasForeignKey(key => key.PersonId);
        });
    }
}
