using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Domain.Books.Repositories;

public interface IBookRepository
{
    public Task<BookId> SaveAsync(Book book);
    public Task<List<Book>> GetAllAsync();
    public Task<Book>GetByIdAsync(BookId bookId);
}
