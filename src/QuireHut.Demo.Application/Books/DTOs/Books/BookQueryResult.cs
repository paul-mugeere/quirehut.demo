namespace QuireHut.Demo.Application.Books.DTOs.Books;

public record BookQueryResult
{
    public Guid BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public IEnumerable<Author> Authors { get; set; }
    public IEnumerable<EditionItem> Editions { get; set; }
};