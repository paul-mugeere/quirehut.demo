namespace QuireHut.Demo.Application;

public record BookCreationDTO(
    string ISBN,
    string Title,
    string Subject,
    string Publisher,
    string Language,
    int NumberOfPages);


public record BookItemCreationDTO(string ISBN);

public static class BookCreationDTOMapper
{
    public static CreateBookCommand MapToCreateBookCommand(this BookCreationDTO book)
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