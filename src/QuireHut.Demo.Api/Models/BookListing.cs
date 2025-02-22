namespace QuireHut.Demo.Api.Models;

public record BookListing
{
    public Guid BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public List<Author> Authors { get; set; } = new ();
    public List<Edition> Editions { get; set; } = new();
}