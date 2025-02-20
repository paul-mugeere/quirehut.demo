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
    public static IQueryable<BookQueryResult> All(this IQueryable<Book> books, BookId? bookId = null)
    {
        return books.AsNoTracking()
            .Where(book => !bookId.HasValue || book.Id == bookId)
            .Select(book => new BookQueryResult
            {
                BookId = book.Id.Value,
                Title = book.Title.ToString(),
                CoverImageUrl = "",
                Authors = EF.Property<ICollection<BookAuthor>>(book, "Authors")
                    .Select(x => new Author(x.PersonId.Value, x.Person.Fullname.ToString())),
                Editions = EF.Property<ICollection<Edition>>(book, "Editions").Select(x => new EditionItem()
                {
                    EditionId = x.Id.Value,
                    Dimensions = Dimensions.CreateNew(x.Dimensions),
                    Price = x.Price,
                    Publisher = Publisher.CreateNew(x.Publisher),
                    NumberOfPages = x.NumberOfPages,
                    PublicationDate = x.PublicationDate,
                    Language = x.Language,
                    Status = (EditionItemStatus)x.Status,
                    Stock = x.Stock,
                    ISBN = x.ISBN.Value,
                })
            });
    }
    
    public static IQueryable<BookTitleWithAuthorsQueryResult> AllEditions(this IQueryable<Book> books, EditionId? editionId=null)
    {
        return books.AsNoTracking().SelectMany(book => book.Editions
            .Where(edition => !editionId.HasValue || edition.Id == editionId).Select(edition =>
            new BookTitleWithAuthorsQueryResult
            {
                BookId = book.Id.Value,
                EditionId = edition.Id.Value,
                CoverImageUrl = "",
                Title = book.Title.ToString(),
                Format = edition.Format,
                Language = edition.Language,
                Authors = EF.Property<ICollection<BookAuthor>>(book, "Authors").Select(x => new
                    Author(x.PersonId.Value, x.Person.Fullname.ToString())),
                Price = edition.Price,
                PublicationYear = edition.PublicationDate.Value.Year,
            }));
    }
    
}