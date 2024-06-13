using Library.Demo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Demo.Infrastructure;

public class BookRepository : IBookRepository
{
    private IDbContextFactory<LibraryDemoDbContext> _dbContextFactory;

    public BookRepository(IDbContextFactory<LibraryDemoDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<BookId> Save(Book book)
    {
        await using var context = _dbContextFactory.CreateDbContext();
        context.Books.Add(book);
        await context.SaveChangesAsync();
        return book.Id;
    }
}
