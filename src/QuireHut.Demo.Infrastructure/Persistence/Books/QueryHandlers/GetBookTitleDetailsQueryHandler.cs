using MediatR;
using Microsoft.EntityFrameworkCore;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Infrastructure.Persistence.Books.QueryHandlers;

public class GetBookTitleDetailsQueryHandler(IDbContextFactory<QuirehutDemoDbContext> dbContextFactory) 
    : IRequestHandler<GetBookTitleDetailsQuery, Result<BookTitleWithAuthorsQueryResult>>
{
    public async Task<Result<BookTitleWithAuthorsQueryResult>> Handle(GetBookTitleDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var context = await dbContextFactory.CreateDbContextAsync(cancellationToken);
            var result = (await context.Books.BookTitleWithAuthorsAsync(new EditionId(request.EditionId))).FirstOrDefault();
            return result == null
                ? Result<BookTitleWithAuthorsQueryResult>.Success($"Edition of id {request.EditionId} not found")
                : Result<BookTitleWithAuthorsQueryResult>.Success(result);
        }
        catch (Exception e)
        {
            return Result<BookTitleWithAuthorsQueryResult>.FromException(e);
        }
    }
}