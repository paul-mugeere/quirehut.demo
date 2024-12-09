namespace QuireHut.Demo.Api.Models;

public record Book
{
    public Guid BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public List<BookAuthor> Authors { get; set; } = new ();
    public List<Edition> Editions { get; set; } = new();
}

public record Dimensions(decimal? Height, decimal? Width, decimal? Depth);