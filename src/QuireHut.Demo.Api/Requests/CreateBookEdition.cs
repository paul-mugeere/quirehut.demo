using QuireHut.Demo.Api.Models;

namespace QuireHut.Demo.Api.Requests;

public record CreateBookEdition
{
    public string ISBN { get;  set;}
    public Format Format { get;  set;}
    public Dimensions? Dimensions { get;  set;} 
    public decimal Price { get;  set; }
    public int NumberOfPages { get; set;}
    public Publisher? Publisher { get; set; } 
    public DateTime? PublicationDate { get;  set;}
    public string Language { get;  set;} = string.Empty;
    public Status Status{get; set;}
}