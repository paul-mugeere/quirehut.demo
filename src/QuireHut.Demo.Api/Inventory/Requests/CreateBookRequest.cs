using QuireHut.Demo.Api.Inventory.Responses;
using QuireHut.Demo.Api.Models;
using QuireHut.Demo.Api.Shared;

namespace QuireHut.Demo.Api.Inventory.Requests;

public record CreateBookRequest(
    string Title,
    string Subject,
    List<Guid> AuthorIds,
    List<CreateEditionRequest> Editions
);


public record CreateEditionRequest
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
