using Library.Demo.Domain;
using MediatR;

namespace Library.Demo.Application;

public record CreateBookCommand(
    string ISBN,
    string Title,
    string Subject,
    string Publisher,
    string Language,
    int NumberOfPages) : IRequest<BookId>{}


public static class CreateBookCommandMapper{
    public static Book MapToBook(this CreateBookCommand command){
        return Book.CreateNew(
            new ISBN(command.ISBN),
            new BookTitle(command.Title),
            new BookSubject(command.Subject));
    }
}
