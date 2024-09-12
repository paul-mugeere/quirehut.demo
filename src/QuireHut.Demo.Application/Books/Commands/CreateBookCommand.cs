using QuireHut.Demo.Domain;
using MediatR;

namespace QuireHut.Demo.Application;

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
            new Title(command.Title),
            new Subject(command.Subject),
            null, 
            null
            );
    }
}
