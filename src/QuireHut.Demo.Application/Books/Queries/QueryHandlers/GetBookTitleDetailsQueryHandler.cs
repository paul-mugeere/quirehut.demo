using MediatR;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Books.Queries.Services;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Books.Queries.QueryHandlers;

public class GetBookTitleDetailsQueryHandler(IBookQueryService bookQueryService)
    : IRequestHandler<GetBookTitleDetailsQuery, Result<BookTitleWithAuthorsQueryResult>>
{
    public async Task<Result<BookTitleWithAuthorsQueryResult>> Handle(GetBookTitleDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await bookQueryService.GetBookTitleWithAuthors(new EditionId(request.EditionId)).ConfigureAwait(false);
          return Result<BookTitleWithAuthorsQueryResult>.Success(result);
        }
        catch (Exception e)
        {
            return Result<BookTitleWithAuthorsQueryResult>.FromException(e);
        }
    }
}