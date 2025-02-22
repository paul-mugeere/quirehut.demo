using Microsoft.EntityFrameworkCore;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Books.Queries.Services;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Infrastructure.Persistence.Books;

public class BookQueryService(IDbContextFactory<QuirehutDemoDbContext> dbContextFactory) : IBookQueryService
{
    public async Task<List<BookListingQueryResult>> GetBookListings()
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        return await context.Books.Aggregates()
            .Select(book => BookListingQueryResult.From(book))
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task<BookListingQueryResult> GetBookListingById(BookId bookId)
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        return await context.Books.Aggregates(bookId)
            .Select(book => BookListingQueryResult.From(book))
            .FirstOrDefaultAsync().ConfigureAwait(false);
    }

    public async Task<List<BookWithAuthorsQueryResult>> GetBooksWithAuthors()
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        return await context.Books.
            BookTitleWithAuthorsAsync()
            .ConfigureAwait(false);
    }

    public async Task<BookWithAuthorsQueryResult> GetBookWithAuthors(EditionId editionId)
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        return (await context.Books.
            BookTitleWithAuthorsAsync(editionId))
            .FirstOrDefault();
    }
}