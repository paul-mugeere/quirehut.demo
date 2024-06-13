using Library.Demo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Demo.Infrastructure;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("books");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
        .HasConversion(c => c.Value, value => new(value));

        builder.Property(x => x.ISBN)
        .HasConversion(c => c.Value, value => new(value));

        builder.Property(x => x.Title)
        .HasConversion(c => c.Value, value => new(value));

        builder.Property(x => x.Subject)
        .HasConversion(c => c.Value, value => new(value));

        builder.OwnsMany(x => x.BookItems, nb =>
        {
            nb.ToTable("booksItems");
            nb.HasKey(k => k.Id);
            nb.Property(p => p.Id)
            .HasConversion(c => c.Value, value => new(value));
            nb.WithOwner().HasForeignKey(key=>key.BookId);
        });

    }
}
