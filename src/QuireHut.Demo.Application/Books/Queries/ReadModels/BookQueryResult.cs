using QuireHut.Demo.Domain.Books;

namespace QuireHut.Demo.Application.Books.Queries.ReadModels;

public record BookQueryResult
{
    public Guid BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public IEnumerable<Author> Authors { get; set; }
    public IEnumerable<EditionItem> Editions { get; set; }

    public static BookQueryResult From(Book book) => new ()
    {
        BookId = book.Id.Value,
        Title = book.Title.ToString(),
        CoverImageUrl = "",
        Authors = book.Authors?.Select(author=>Author.From(author.Person)),
        Editions = book.Editions.Select(EditionItem.From)
    };
}