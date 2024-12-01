using QuireHut.Demo.Application.Books.Commands;
using QuireHut.Demo.Application.Books.DTOs;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Domain.Books.Entities;
using QuireHut.Demo.Domain.Persons.ValueObjects;

namespace QuireHut.Demo.Api.Books.Requests;

public record CreateBookRequest(
    string Title,
    string Subject,
    List<Guid> Authors,
    List<CreateEditionRequest> Editions
);


public record CreateEditionRequest
{
    public string ISBN { get;  set;}
    public EditionItemFormat Format { get;  set;}
    public EditionItemDimensions? Dimensions { get;  set;} 
    public decimal Price { get;  set; }
    public int NumberOfPages { get; set;}
    public EditionItemPublisher? Publisher { get; set; } 
    public DateTime? PublicationDate { get;  set;}
    public string Language { get;  set;} = string.Empty;
    public EditionItemStatus Status{get; set;}
}

public static class CreateBookRequestMapper
{
    public static CreateBookCommand MapToCreateBookCommand(this CreateBookRequest bookCreateRequest)
    {
        return new CreateBookCommand(
            bookCreateRequest.Title,
            bookCreateRequest.Subject,
            MapEditions(bookCreateRequest),
            bookCreateRequest.Authors);
    }

    private static List<EditionItemDetails> MapEditions(CreateBookRequest bookCreateRequest)
    {
        return bookCreateRequest.Editions?.Select(x=>new EditionItemDetails()
        {
            Dimensions = x.Dimensions,
            ISBN = x.ISBN,
            Price = x.Price,
            NumberOfPages = x.NumberOfPages,
            Publisher = x.Publisher,
            Status = x.Status,
            PublicationDate = x.PublicationDate,
            Language = x.Language,
            Format = x.Format
        }).ToList()??[];
    }
}