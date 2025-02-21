using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.Entities;
using QuireHut.Demo.Domain.Books.Enums;

namespace QuireHut.Demo.Application.Books.DTOs.Books;

public record BookTitleWithAuthorsQueryResult
{
    public Guid EditionId { get; init; }
    public Guid BookId { get; init; }
    public string Title { get; init; } = string.Empty;
    public string CoverImageUrl { get; init; } = string.Empty;
    public Format Format { get; set; }
    public decimal Price { get; init; }
    public int? PublicationYear { get; init; }
    public string Language { get; init; } = string.Empty;
    public IEnumerable<Author> Authors { get; init; }

    public static BookTitleWithAuthorsQueryResult? From(Edition? edition) =>
        edition is null ? null:
        new BookTitleWithAuthorsQueryResult
        {
            BookId = edition.BookId.Value,
            EditionId = edition.Id.Value,
            CoverImageUrl = "",
            Format = edition.Format,
            Language = edition.Language,
            Price = edition.Price,
            PublicationYear = edition.PublicationDate.Value.Year,
        };
}