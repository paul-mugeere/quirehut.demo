using QuireHut.Demo.Domain.Books.Enums;

namespace QuireHut.Demo.Application.Books.Queries.ReadModels;

public record BookWithAuthorsQueryResult
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

}