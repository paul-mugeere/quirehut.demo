namespace QuireHut.Demo.Api.Models;

public record BookListing
{
    public Guid EditionId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public List<BookAuthor> Authors { get; set; } = new ();
    public EditionFormat Format { get;  set;}
    public decimal Price { get;  set; }
    public string Language { get;  set;} = string.Empty;
}