using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.Entities;
using QuireHut.Demo.Domain.Persons;

namespace QuireHut.Demo.Application.Books.Mappers;

public interface IBookTitleMapper
{
    BookTitleCollectionDto MapToBookTitlesDto(List<Book> books, IEnumerable<Person> authors);
}

public class BookTitleMapper(IBookAuthorMapper bookAuthorMapper) : IBookTitleMapper
{
    public BookTitleCollectionDto MapToBookTitlesDto(List<Book> books, IEnumerable<Person> authors)
    {
        var bookTitles = books.SelectMany(book => 
            book.Editions.Select(edition => CreateBookTitleDto(book,edition,authors))).ToList();
        return  BookTitleCollectionDto.CreateNew(bookTitles);
    }
    
    private BookTitleDto CreateBookTitleDto(Book book, Edition edition, IEnumerable<Person> authors)
    {
        return new BookTitleDto
        {
            BookId = book.Id.Value,
            EditionId = edition.Id.Value,
            Title = book.Title.Value,
            Format = edition.Format,
            Language = edition.Language,
            Price = edition.Price,
            CoverImageUrl = "",
            PublicationDate = edition.PublicationDate,
            Authors = bookAuthorMapper.MapToBookAuthorDtoList(authors,book.Authors)
        };
    }
}