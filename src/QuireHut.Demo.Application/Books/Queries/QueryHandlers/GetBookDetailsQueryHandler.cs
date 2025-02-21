using MediatR;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Books.Queries.Services;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Books.Queries.QueryHandlers;

public class GetBookDetailsQueryHandler(IBookQueryService bookQueryService)
    : IRequestHandler<GetBookDetailsQuery, Result<BookQueryResult>>
{
    public async Task<Result<BookQueryResult>> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await bookQueryService.GetBooksWithId(new BookId(request.BookId));
            return Result<BookQueryResult>.Success(result??new BookQueryResult());
        }
        catch (Exception e)
        {
            return Result<BookQueryResult>.FromException(e);
        }
    }
}