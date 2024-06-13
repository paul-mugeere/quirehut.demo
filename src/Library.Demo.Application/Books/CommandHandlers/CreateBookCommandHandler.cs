using Library.Demo.Domain;
using MediatR;

namespace Library.Demo.Application;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookId>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookId> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        return await _bookRepository.Save(command.MapToBook());;
    }
}
