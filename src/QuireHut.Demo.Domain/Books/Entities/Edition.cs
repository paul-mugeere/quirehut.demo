using QuireHut.Demo.Domain.Books.Enums;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Domain.Books.Entities;

public class Edition
{
    public EditionId Id { get;} = EditionId.Empty;
    public BookId BookId { get;}
    public Book Book { get;}
    public ISBN ISBN { get;} = ISBN.Empty; // should an edition have its own ISBN, some can!
    public Format Format { get; private set; }
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
        ISBN isbn,
        Format format, 
        string language,
        Publisher publisher,
        DateTime? publicationDate,
        Dimensions dimensions,
        decimal price, 
        int numberOfPages,
        EditionStatus status)
    {
        return new(isbn,format,price,language,publisher,publicationDate,dimensions,numberOfPages,status);
    }

    private  Edition(
        ISBN isbn,
        Format format,
        decimal price,
        string language,
        Publisher publisher,
        DateTime? publicationDate,
        Dimensions dimensions,
        int numberOfPages,
        EditionStatus status)
    {
        Id = EditionId.CreateNew();
        ISBN = isbn;
        Format = format;
        Language = language;
        Publisher = publisher;
        PublicationDate = publicationDate;
        Dimensions = dimensions;
        NumberOfPages = numberOfPages;
        Status = status;
        Price = price;
    }
    private Edition() { }
}