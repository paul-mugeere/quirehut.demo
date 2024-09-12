namespace QuireHut.Demo.Application;

public interface IBookService
{
    public Task<Result<Guid>> CreateBook(BookCreationDTO book);
}
