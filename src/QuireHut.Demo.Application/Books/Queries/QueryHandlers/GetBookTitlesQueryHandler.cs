using MediatR;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Books.Queries.Services;
using QuireHut.Demo.Application.Common;

namespace QuireHut.Demo.Application.Books.Queries.QueryHandlers;

public class GetBookTitlesQueryHandler(IBookQueryService bookQueryService)
    : IRequestHandler<GetBookTitlesQuery, Result<BookTitleCollectionQueryResult>>
{
    public async Task<Result<BookTitleCollectionQueryResult>> Handle(GetBookTitlesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var bookTitles = await bookQueryService.GetBookTitlesWithAuthors().ConfigureAwait(false);
            return Result<BookTitleCollectionQueryResult>.Success(BookTitleCollectionQueryResult.CreateNew(bookTitles));
        }
        catch (Exception e)
        {
            return Result<BookTitleCollectionQueryResult>.Failure(e.Message);
        }
    }
}