using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Books.Services;

public interface IBookQueryService
{
    Task<List<BookTitleWithAuthorsQueryResult>> GetBookTitlesWithAuthorsAsync();
    Task<List<BookQueryResult>> GetBooksAsync();
    Task<BookQueryResult?> GetBookByIdAsync(BookId bookId);
    Task<BookTitleWithAuthorsQueryResult?> GetBookTitleByEditionIdAsync(EditionId editionId);
}
