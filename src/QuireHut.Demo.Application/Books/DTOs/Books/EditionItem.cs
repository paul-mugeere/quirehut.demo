namespace QuireHut.Demo.Application.Books.DTOs.Books;


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
    
}
