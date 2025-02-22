using MediatR;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Books.Queries.Services;
using QuireHut.Demo.Application.Common;

namespace QuireHut.Demo.Application.Books.Queries.QueryHandlers;

public class GetBooksQueryHandler(IBookQueryService bookQueryService)
    : IRequestHandler<GetBooksQuery, Result<BooksCollectionQueryResult>>
{
    public async Task<Result<BooksCollectionQueryResult>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var bookTitles = await bookQueryService.GetBooksWithAuthors().ConfigureAwait(false);
            return Result<BooksCollectionQueryResult>.Success(BooksCollectionQueryResult.CreateNew(bookTitles));
        }
        catch (Exception e)
        {
            return Result<BooksCollectionQueryResult>.Failure(e.Message);
        }
    }
}