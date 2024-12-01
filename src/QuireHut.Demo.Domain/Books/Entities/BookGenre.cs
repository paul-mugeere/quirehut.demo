using QuireHut.Demo.Domain.Books.ValueObjects;
using QuireHut.Demo.Domain.Genres;
using QuireHut.Demo.Domain.Genres.ValueObjects;

namespace QuireHut.Demo.Domain.Books.Entities;

public class BookGenre
{
    public Guid Id { get; }
    public BookId BookId { get; }
    public Book Book { get; }
    public GenreId GenreId { get; }
    public Genre Genre { get; }

    private BookGenre(Guid id, BookId bookId, GenreId genreId)
    {
        Id = id;
        BookId = bookId;
        GenreId = genreId;
    }

    public static BookGenre CreateNew(BookId bookId, GenreId genreId) =>new (Guid.NewGuid(), bookId, genreId);
}