namespace QuireHut.Demo.Application.Books.DTOs.Books;

public record BookDetailsDto
{
    public Guid BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public List<BookAuthorDto> Authors { get; set; } = new ();
    public List<EditionDto> Editions { get; set; } = new();
}