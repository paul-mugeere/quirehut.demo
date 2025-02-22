namespace QuireHut.Demo.Api.Models;

public record BookDetails
{
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Author> Authors { get; set; } = [];
    public Format Format { get;  set;}
    public string Language { get;  set;} = string.Empty;
    public int? PublicationYear { get; set; }
}