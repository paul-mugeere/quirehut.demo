using QuireHut.Demo.Domain;
using Microsoft.EntityFrameworkCore;

namespace QuireHut.Demo.Infrastructure;

public class BookRepository : IBookRepository
{
    private IDbContextFactory<LibraryDemoDbContext> _dbContextFactory;

    public BookRepository(IDbContextFactory<LibraryDemoDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<BookId> Save(Book book)
    {
        return book.Id;
    }
}
