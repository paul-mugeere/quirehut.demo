using MediatR;
using Microsoft.EntityFrameworkCore;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Common;

namespace QuireHut.Demo.Infrastructure.Persistence.Books.QueryHandlers;

public class GetBooksQueryHandler(IDbContextFactory<QuirehutDemoDbContext> dbContextFactory) 
    : IRequestHandler<GetBooksQuery, Result<BookCollectionQueryResult>>
{
    public async Task<Result<BookCollectionQueryResult>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var context = await dbContextFactory.CreateDbContextAsync(cancellationToken);
            var bookTitles = await context.Books.Aggregates()
                .Select(book => BookQueryResult.From(book))
                .ToListAsync(cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return Result<BookCollectionQueryResult>.Success(BookCollectionQueryResult.CreateNew(bookTitles));
        }
        catch (Exception e)
        {
            return Result<BookCollectionQueryResult>.FromException(e);
        }
    }
}