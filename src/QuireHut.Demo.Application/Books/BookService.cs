
using QuireHut.Demo.Domain;
using MediatR;

namespace QuireHut.Demo.Application;

public class BookService : IBookService
{
    private readonly IMediator _mediator;

    public BookService(IMediator mediator)
    {
        _mediator = mediator;
    }

    //ToDo: shoult we return a valueObject instead?
    public async Task<Result<Guid>> CreateBook(BookCreationDTO book)
    {
        try
        {
            var bookCreationResult = await _mediator.Send(book.MapToCreateBookCommand());
            return Result<Guid>.Success(bookCreationResult.Value);
        }
        catch (Exception e)
        {
            return Result<Guid>.FromException(e);
        }
    }
}
