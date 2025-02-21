using Microsoft.EntityFrameworkCore;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Books.Queries.Services;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Infrastructure.Persistence.Books;

public class BookQueryService(IDbContextFactory<QuirehutDemoDbContext> dbContextFactory) : IBookQueryService
{
    public async Task<List<BookQueryResult>> GetAllBooks()
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        return await context.Books.Aggregates()
            .Select(book => BookQueryResult.From(book))
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task<BookQueryResult> GetBooksWithId(BookId bookId)
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        return await context.Books.Aggregates(bookId)
            .Select(book => BookQueryResult.From(book))
            .FirstOrDefaultAsync().ConfigureAwait(false);
    }

    public async Task<List<BookTitleWithAuthorsQueryResult>> GetBookTitlesWithAuthors()
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        return await context.Books.BookTitleWithAuthorsAsync().ConfigureAwait(false);
    }

    public async Task<BookTitleWithAuthorsQueryResult> GetBookTitleWithAuthors(EditionId editionId)
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        return (await context.Books.BookTitleWithAuthorsAsync(editionId)).FirstOrDefault();
    }
}