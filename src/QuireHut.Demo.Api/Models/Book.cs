namespace QuireHut.Demo.Api.Models;

public record Book
{
    public Guid BookId { get; set; }
    public Guid EditionId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public List<Author> Authors { get; set; } = [];
    public Format Format { get;  set;}
    public decimal Price { get;  set; }
    public string Language { get;  set;} = string.Empty;
}