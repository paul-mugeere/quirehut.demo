using Microsoft.EntityFrameworkCore;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.Repositories;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Infrastructure.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private IDbContextFactory<LibraryDemoDbContext> _dbContextFactory;

    public BookRepository(IDbContextFactory<LibraryDemoDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<BookId> SaveAsync(Book book)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        dbContext.Add(book);
        await dbContext.SaveChangesAsync();
        return book.Id;
    }

    public async Task<List<Book>>GetAllAsync()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.Books.ToListAsync();
    }

    public async Task<Book> GetByIdAsync(BookId bookId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.Books.FindAsync(bookId);
    }
}
