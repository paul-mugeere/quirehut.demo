namespace QuireHut.Demo.Api.Models;

public record BookTitle
{
    public Guid BookId { get; set; }
    public Guid EditionId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public List<BookTitleAuthor> Authors { get; set; } = [];
    public Format Format { get;  set;}
    public decimal Price { get;  set; }
    public string Language { get;  set;} = string.Empty;
}

public record BookTitleDetails
{
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<BookTitleAuthor> Authors { get; set; } = [];
    public Format Format { get;  set;}
    public string Language { get;  set;} = string.Empty;
    public int? PublicationYear { get; set; }
}

public record BookTitleAuthor(Guid Id,string Fullname);