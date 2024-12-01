namespace QuireHut.Demo.Application.Books.DTOs.Books;

public record BookItemDetails
{
    public Guid BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public List<BookItemAuthor> Authors { get; set; } = new ();
    public EditionItemDetails Edition { get; set; } = new();
}