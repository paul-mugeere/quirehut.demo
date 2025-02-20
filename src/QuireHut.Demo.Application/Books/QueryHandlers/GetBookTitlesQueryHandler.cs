using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.Services;
using QuireHut.Demo.Application.Common;

namespace QuireHut.Demo.Application.Books.QueryHandlers;

public class GetBookTitlesQueryHandler(
    IBookQueryService bookQueryService)
    : IRequestHandler<GetBookTitlesQuery, Result<BookTitleCollectionQueryResult>>
{

    public async Task<Result<BookTitleCollectionQueryResult>> Handle(GetBookTitlesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var bookTitles = await bookQueryService.GetBookTitlesWithAuthorsAsync().ConfigureAwait(false);
            return Result<BookTitleCollectionQueryResult>.Success(BookTitleCollectionQueryResult.CreateNew(bookTitles));
        }
        catch (Exception e)
        {
            return Result<BookTitleCollectionQueryResult>.Failure(e.Message);
        }
        
    }
}