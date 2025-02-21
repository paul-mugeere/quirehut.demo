using MediatR;
using Microsoft.EntityFrameworkCore;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Infrastructure.Persistence.Books.QueryHandlers;

public class GetBookDetailsQueryHandler(IDbContextFactory<QuirehutDemoDbContext> dbContextFactory) 
    : IRequestHandler<GetBookDetailsQuery, Result<BookQueryResult>>
{
    public async Task<Result<BookQueryResult>> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var context = await dbContextFactory.CreateDbContextAsync(cancellationToken);
            var result= await context.Books.Aggregates(new BookId(request.BookId))
                .Select(book => BookQueryResult.From(book))
                .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
            return Result<BookQueryResult>.Success(result??new BookQueryResult());
        }
        catch (Exception e)
        {
            return Result<BookQueryResult>.FromException(e);
        }
    }
}