using Microsoft.EntityFrameworkCore;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.Entities;
using QuireHut.Demo.Domain.Books.ValueObjects;
using Dimensions = QuireHut.Demo.Application.Books.DTOs.Books.Dimensions;
using Publisher = QuireHut.Demo.Application.Books.DTOs.Books.Publisher;

namespace QuireHut.Demo.Infrastructure.Persistence.Services;

public static class BooksQueries
{
    public static IQueryable<Book> Aggregates(this IQueryable<Book> books, BookId? bookId = null)
    {
        return books
            .Include("Authors.Person")
            .Where(book => !bookId.HasValue || book.Id == bookId).AsNoTracking();
    }

    public static async Task<List<BookTitleWithAuthorsQueryResult>> BookTitleWithAuthorsAsync(this IQueryable<Book> books,
        EditionId? editionId = null)
    {
        return await books.AsNoTracking().SelectMany(book => book.Editions
            .Where(edition => !editionId.HasValue || edition.Id == editionId).Select(edition =>
            new BookTitleWithAuthorsQueryResult
            {
                BookId = book.Id.Value,
                EditionId = edition.Id.Value,
                CoverImageUrl = "",
                Title = book.Title.ToString(),
                Format = edition.Format,
                Language = edition.Language,
                Authors = EF.Property<ICollection<BookAuthor>>(book, "Authors")
                    .Select(author => Author.From(author.Person)),
                Price = edition.Price,
                PublicationYear = edition.PublicationDate.Value.Year,
            }
        )).ToListAsync();
    }

}