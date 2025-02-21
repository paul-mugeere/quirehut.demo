using Microsoft.EntityFrameworkCore;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Services;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Infrastructure.Persistence.Services;

public class BooksQueryService(IDbContextFactory<QuirehutDemoDbContext> dbContextFactory) : IBookQueryService
{
    public async Task<List<BookTitleWithAuthorsQueryResult>> GetBookTitlesWithAuthorsAsync()
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        return await context.Books.BookTitleWithAuthorsAsync().ConfigureAwait(false);
    }

    public async Task<List<BookQueryResult>> GetBooksAsync()
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        return await context.Books.Aggregates()
            .Select(book => BookQueryResult.From(book))
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task<BookQueryResult?> GetBookByIdAsync(BookId bookId)
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        return await context.Books.Aggregates(bookId)
            .Select(book => BookQueryResult.From(book))
            .FirstOrDefaultAsync().ConfigureAwait(false);
    }
    public async Task<BookTitleWithAuthorsQueryResult?> GetBookTitleByEditionIdAsync(EditionId editionId)
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        return (await context.Books.BookTitleWithAuthorsAsync(editionId).ConfigureAwait(false)).FirstOrDefault();
    }
}