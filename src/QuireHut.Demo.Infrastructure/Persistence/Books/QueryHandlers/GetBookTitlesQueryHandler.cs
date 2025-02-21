using MediatR;
using Microsoft.EntityFrameworkCore;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Common;

namespace QuireHut.Demo.Infrastructure.Persistence.Books.QueryHandlers;

public class GetBookTitlesQueryHandler(IDbContextFactory<QuirehutDemoDbContext> dbContextFactory) 
    : IRequestHandler<GetBookTitlesQuery, Result<BookTitleCollectionQueryResult>>
{
    public async Task<Result<BookTitleCollectionQueryResult>> Handle(GetBookTitlesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var context = await dbContextFactory.CreateDbContextAsync(cancellationToken);
            var bookTitles = await context.Books.BookTitleWithAuthorsAsync().ConfigureAwait(false);
            return Result<BookTitleCollectionQueryResult>.Success(BookTitleCollectionQueryResult.CreateNew(bookTitles));
        }
        catch (Exception e)
        {
            return Result<BookTitleCollectionQueryResult>.Failure(e.Message);
        }
    }
}