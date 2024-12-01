using MediatR;
using QuireHut.Demo.Application.Books.Commands;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.Repositories;

namespace QuireHut.Demo.Application.Books.CommandHandlers;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Result<Guid>>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Result<Guid>> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var bookCreationResult = await _bookRepository.SaveAsync(command.MapToBook());
            return Result<Guid>.Success(bookCreationResult.Value);
        }
        catch (Exception e)
        {
            return Result<Guid>.FromException(e);
        }
    }
}
