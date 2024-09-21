using QuireHut.Demo.Application;

namespace QuireHut.Demo.Api.Controllers;

public record CreateBookRequest(
    string ISBN,
    string Title,
    string Subject,
    string Publisher,
    string Language,
    int NumberOfPages
);

public static class BookCreationMapper
{
    public static CreateBookDto MapToBookCreationDTO(this CreateBookRequest bookCreateRequest)
    {
        return new CreateBookDto(
            bookCreateRequest.ISBN,
            bookCreateRequest.Title,
            bookCreateRequest.Subject,
            bookCreateRequest.Publisher,
            bookCreateRequest.Language,
            bookCreateRequest.NumberOfPages);
    }
}