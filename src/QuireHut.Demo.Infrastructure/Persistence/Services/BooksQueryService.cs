using Microsoft.EntityFrameworkCore;
using QuireHut.Demo.Application.Books.Services;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.ValueObjects;
using QuireHut.Demo.Domain.Persons;

namespace QuireHut.Demo.Infrastructure.Persistence.Services;

public class BooksQueryService(IDbContextFactory<QuirehutDemoDbContext> dbContextFactory) : IBookQueryService
{
    public async Task<(List<Book> books, List<Person> authors)> GetBooksAsync()
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        var books = await context.Books.AsNoTracking().ToListAsync();
        var authors = await GetBookAuthorsAsync(books, context);
         return (books, authors);
    }

    public async Task<(Book? book, List<Person> authors)> GetBookByIdAsync(BookId bookId)
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        var book = await context.Books.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == bookId);
        if (book == null) return (null, []);
        
        var authors = await GetBookAuthorsAsync([book], context);
        return (book, authors);
    }

    private static async Task<List<Person>> GetBookAuthorsAsync(List<Book> books, QuirehutDemoDbContext context)
    {
        var personIds = books.SelectMany(book=>book.Authors.Select(author=> author.PersonId)).Distinct().ToList();
        var authors = await context.Persons.Where(author => personIds.Contains(author.Id)).AsNoTracking().ToListAsync();
        return authors;
    }
}