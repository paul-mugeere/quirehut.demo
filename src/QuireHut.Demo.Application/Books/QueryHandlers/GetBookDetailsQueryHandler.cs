using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.Services;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Books.QueryHandlers;

public class GetBookDetailsQueryHandler(
    IBookQueryService bookQueryService)
    : IRequestHandler<GetBookDetailsQuery, Result<BookQueryResult>>
{

    public async Task<Result<BookQueryResult>> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await bookQueryService.GetBookByIdAsync(new BookId(request.BookId))?? new BookQueryResult();
            return Result<BookQueryResult>.Success(result);
        }
        catch (Exception e)
        {
            return Result<BookQueryResult>.FromException(e);
        }
    }
}