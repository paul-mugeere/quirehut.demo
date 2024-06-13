using Library.Demo.Application;

namespace Library.Demo.Api.Controllers;

public record BookCreateRequest(
    string ISBN,
    string Title,
    string Subject,
    string Publisher,
    string Language,
    int NumberOfPages
);

public static class BookCreationMapper
{
    public static BookCreationDTO MapToBookCreationDTO(this BookCreateRequest bookCreateRequest)
    {
        return new BookCreationDTO(
            bookCreateRequest.ISBN,
            bookCreateRequest.Title,
            bookCreateRequest.Subject,
            bookCreateRequest.Publisher,
            bookCreateRequest.Language,
            bookCreateRequest.NumberOfPages);
    }
}