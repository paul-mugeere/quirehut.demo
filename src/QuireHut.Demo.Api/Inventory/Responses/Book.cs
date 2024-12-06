namespace QuireHut.Demo.Api.Inventory.Models;

public record Book
{
    public Guid BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public List<BookAuthor> Authors { get; set; } = new ();
    public List<Edition> Editions { get; set; } = new();
}

public record BookDetails
{
    public Guid BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public List<BookAuthor> Authors { get; set; } = new ();
    public List<Edition> Editions { get; set; } = new();
}
public record BookAuthor
{
    public Guid Id { get; set; }
    public string Fullname { get; set; }
}

public record Edition
{
    public Guid EditionId { get; set; }
    public string ISBN { get;  set;}
    public EditionFormat Format { get;  set;}
    public Dimensions? Dimensions { get;  set;} 
    public decimal Price { get;  set; }
    public int NumberOfPages { get; set;}
    public int Stock { get; set; }
    public Publisher? Publisher { get; set; } 
    public DateTime? PublicationDate { get;  set;}
    public string Language { get;  set;} = string.Empty;
    public EditionStatus Status{get; set;}   
}

public enum EditionStatus
{
    Planned =1,
    Published =2,
    OutOfPrint =3,
    Discontinued =4
}

public record Dimensions(decimal? Height, decimal? Width, decimal? Depth);

public record Publisher(string? Name);

public enum EditionFormat
{
    HardPaper = 1,
    PaperBack = 2,
    AudioBook = 3,
    Ebook = 4
}