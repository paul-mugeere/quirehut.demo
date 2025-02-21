using QuireHut.Demo.Domain.Books.Entities;

namespace QuireHut.Demo.Application.Books.Queries.ReadModels;


public record EditionItem
{
    public Guid EditionId { get; set; }
    public string ISBN { get;  set;}
    public EditionItemFormat Format { get;  set;}
    public Dimensions? Dimensions { get;  set;} 
    public decimal Price { get;  set; }
    public int NumberOfPages { get; set;}
    public int Stock { get; set; }
    public Publisher? Publisher { get; set; } 
    public DateTime? PublicationDate { get;  set;}
    public string Language { get;  set;} = string.Empty;
    public EditionItemStatus Status{get; set;}

    public static EditionItem From(Edition edition) => new ()
    {
        EditionId = edition.Id.Value,
        Dimensions = Dimensions.From(edition.Dimensions),
        Price = edition.Price,
        Publisher = Publisher.From(edition.Publisher),
        NumberOfPages = edition.NumberOfPages,
        PublicationDate = edition.PublicationDate,
        Language = edition.Language,
        Status = (EditionItemStatus)edition.Status,
        Stock = edition.Stock,
        ISBN = edition.ISBN.Value
    };

}
