namespace QuireHut.Demo.Application;

public record CreateBookDto(
    string ISBN,
    string Title,
    string Subject,
    string Publisher,
    string Language,
    int NumberOfPages);


public static class CreateBookDtoMapper
{
    public static CreateBookCommand MapToCreateBookCommand(this CreateBookDto book)
    {
        return new CreateBookCommand(
            book.ISBN, 
            book.Title, 
            book.Subject, 
            book.Publisher, 
            book.Language, 
            book.NumberOfPages);
    }
}