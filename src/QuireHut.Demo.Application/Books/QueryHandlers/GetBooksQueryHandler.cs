using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.Services;
using QuireHut.Demo.Application.Common; 

namespace QuireHut.Demo.Application.Books.QueryHandlers;

public class GetBooksQueryHandler(
    IBookQueryService bookQueryService)
    : IRequestHandler<GetBooksQuery, Result<BookCollectionQueryResult>>
{
    public async Task<Result<BookCollectionQueryResult>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var bookTitles = await bookQueryService.GetBooksAsync().ConfigureAwait(false);
            return Result<BookCollectionQueryResult>.Success(BookCollectionQueryResult.CreateNew(bookTitles));
        }
        catch (Exception e)
        {
            return Result<BookCollectionQueryResult>.FromException(e);
        }
    }

}