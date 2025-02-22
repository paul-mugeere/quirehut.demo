using MediatR;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Books.Queries.Services;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Books.Queries.QueryHandlers;

public class GetBookDetailsQueryHandler(IBookQueryService bookQueryService)
    : IRequestHandler<GetBookDetailsQuery, Result<BookWithAuthorsQueryResult>>
{
    public async Task<Result<BookWithAuthorsQueryResult>> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await bookQueryService.GetBookWithAuthors(new EditionId(request.EditionId)).ConfigureAwait(false);
          return Result<BookWithAuthorsQueryResult>.Success(result);
        }
        catch (Exception e)
        {
            return Result<BookWithAuthorsQueryResult>.FromException(e);
        }
    }
}