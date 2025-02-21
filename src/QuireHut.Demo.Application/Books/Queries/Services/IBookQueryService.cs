using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Books.Queries.Services;

public interface IBookQueryService
{
    public Task<List<BookQueryResult>> GetAllBooks(); 
    public Task<BookQueryResult> GetBooksWithId(BookId bookId); 
    public Task<List<BookTitleWithAuthorsQueryResult>> GetBookTitlesWithAuthors(); 
    public Task<BookTitleWithAuthorsQueryResult> GetBookTitleWithAuthors(EditionId editionId); 
}