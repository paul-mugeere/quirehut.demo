using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.ValueObjects;
using QuireHut.Demo.Domain.Persons;

namespace QuireHut.Demo.Application.Books.Services;

public interface IBookQueryService
{
    Task<(List<Book> books, List<Person> authors)> GetBooksAsync();
    Task<(Book? book, List<Person> authors)> GetBookByIdAsync(BookId bookId);
}
