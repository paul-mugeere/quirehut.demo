using MediatR;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Books.Queries.Services;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Books.Queries.QueryHandlers;

public class GetBookListingDetailsQueryHandler(IBookQueryService bookQueryService)
    : IRequestHandler<GetBookListingDetailsQuery, Result<BookListingQueryResult>>
{
    public async Task<Result<BookListingQueryResult>> Handle(GetBookListingDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await bookQueryService.GetBookListingById(new BookId(request.BookId));
            return Result<BookListingQueryResult>.Success(result??new BookListingQueryResult());
        }
        catch (Exception e)
        {
            return Result<BookListingQueryResult>.FromException(e);
        }
    }
}