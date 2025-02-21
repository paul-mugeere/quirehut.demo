using MediatR;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.Repositories;

namespace QuireHut.Demo.Application.Books.Commands.CommandHandlers;

public class CreateBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<CreateBookCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var bookCreationResult = await bookRepository.SaveAsync(command.MapToBook());
            return Result<Guid>.Success(bookCreationResult.Value);
        }
        catch (Exception e)
        {
            return Result<Guid>.FromException(e);
        }
    }
}