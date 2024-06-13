namespace Library.Demo.Domain;

public interface IBookRepository
{
    public Task<BookId> Save(Book book);
}
