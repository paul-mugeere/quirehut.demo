using MediatR;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Books.Queries.Services;
using QuireHut.Demo.Application.Common;

namespace QuireHut.Demo.Application.Books.Queries.QueryHandlers;

public class GetBookListingsQueryQueryHandler(IBookQueryService bookQueryService)
    : IRequestHandler<GetBookListingsQuery, Result<BookListingCollectionQueryResult>>
{
    public async Task<Result<BookListingCollectionQueryResult>> Handle(GetBookListingsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var bookTitles = await bookQueryService.GetBookListings();
            return Result<BookListingCollectionQueryResult>.Success(BookListingCollectionQueryResult.CreateNew(bookTitles));
        }
        catch (Exception e)
        {
            return Result<BookListingCollectionQueryResult>.FromException(e);
        }
    }
}