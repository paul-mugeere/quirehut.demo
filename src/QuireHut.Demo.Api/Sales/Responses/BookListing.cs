namespace QuireHut.Demo.Api.Sales.Models;

public record BookListing
{
    public Guid EditionId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public List<BookListingAuthor> Authors { get; set; } = new ();
    public BookListingFormat BookListingFormat { get;  set;}
    public decimal Price { get;  set; }
    public string Language { get;  set;} = string.Empty;
}