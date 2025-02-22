using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Books.Queries.Services;

public interface IBookQueryService
{
    public Task<List<BookListingQueryResult>> GetBookListings(); 
    public Task<BookListingQueryResult> GetBookListingById(BookId bookId); 
    public Task<List<BookWithAuthorsQueryResult>> GetBooksWithAuthors(); 
    public Task<BookWithAuthorsQueryResult> GetBookWithAuthors(EditionId editionId); 
}