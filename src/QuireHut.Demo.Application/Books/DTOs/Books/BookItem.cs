using QuireHut.Demo.Domain.Persons.ValueObjects;

namespace QuireHut.Demo.Application.Books.DTOs.Books;

public record BookItem
{
    public Guid BookId { get; set; }
    public Guid EditionId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    
    public EditionItemFormat Format { get;  set;} 
    public List<BookItemAuthor> Authors { get; set; } = new ();
    public decimal Price { get;  set; }
    public DateTime? PublicationDate { get;  set;}
}

public record BookItemAuthor
{
    public string Fullname { get; set; }
}



public enum EditionItemStatus
{
    Planned =1,
    Published =2,
    OutOfPrint =3,
    Discontinued =4
}
public record EditionItemPublisher(string? Name);
public record EditionItemDimensions(decimal? Height, decimal? Width, decimal? Depth);
public enum EditionItemFormat
{
    HardPaper = 1,
    PaperBack = 2,
    AudioBook = 3,
    Ebook = 4
}