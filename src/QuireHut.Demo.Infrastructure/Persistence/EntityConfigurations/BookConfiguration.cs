using QuireHut.Demo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuireHut.Demo.Infrastructure;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        // builder.ToTable("books");
        // builder.HasKey(x => x.Id);

        // builder.Property(x => x.Id)
        // .HasConversion(c => c.Value, value => new(value));

        // builder.Property(x => x.ISBN)
        // .HasConversion(c => c.Value, value => new(value));

        // builder.Property(x => x.Title)
        // .HasConversion(c => c.Value, value => new(value));

        // builder.Property(x => x.Subject)
        // .HasConversion(c => c.Value, value => new(value));

        // builder.OwnsMany(x => x.Editions, nb =>
        // {
        //     nb.ToTable("editions");
        //     nb.HasKey(k => k.Id);
        //     nb.Property(p => p.Id)
        //     .HasConversion(c => c.Value, value => new(value));
        //     nb.Property(p => p.ISBN)
        //     .HasConversion(c => c.Value, value => new(value));
        //     nb.WithOwner().HasForeignKey(key=>key.BookId);
        // });

    }
}
