
using QuireHut.Demo.Domain;

public class Edition
{
    public EditionId Id { get;} = EditionId.Empty;
    public BookId BookId { get; private set;}
    public Book Book { get;}
    public ISBN ISBN { get; private set;} = ISBN.Empty; // should an edition have its own ISBN, some can!
    public Format Format { get; private set;}
    public Dimensions? Dimensions { get; private set;} 
    public decimal Price { get; private set; }
    public int NumberOfPages { get; private set;}
    public int Stock { get; private set; }
    public Publisher? Publisher { get;} 
    public DateTime? PublicationDate { get; private set;}
    public string Language { get; private set;} = string.Empty;
    public EditionStatus Status{get; private set;}

    public void UpdatePrice(decimal price) {
        Price = price;
     }

    public void UpdateStock(int stock) {
        Stock = stock;
     }

    public void AssignFormat(Format format) { }

    public void AssignPublisher(Publisher publisher) { }

    public void UpdateStatus(EditionStatus status) {
        Status = status;
     }

    public static Edition CreateNew(
        EditionId id,
        ISBN isbn,
        Format format, 
        string language,
        Dimensions dimensions,
        decimal price, 
        int numberOfPages,
        EditionStatus status)
    {
        return new(id,isbn,format,language,dimensions,numberOfPages,status);
    }

    private  Edition(
        EditionId id,
        ISBN isbn,
        Format format,
        string language,
        Dimensions dimensions,
        int numberOfPages,
        EditionStatus status)
    {
            Id = id;
            ISBN = isbn;
            Format = format;
            Language = language;
            Dimensions = dimensions;
            NumberOfPages = numberOfPages;
            Status = status;
    }
    private Edition() { }
}
