using AutoMapper;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Persons;

namespace QuireHut.Demo.Application.Books.Mappers;

public interface IBookMapper
{
    BookDto MapToBookDto(Book book);
    BookDetailsDto MapToBookDetailsDto(Book book, IEnumerable<Person> persons);
}

public class BookMapper(IMapper mapper, IBookAuthorMapper bookAuthorMapper) : IBookMapper
{
    public BookDto MapToBookDto(Book book)
    {
        return mapper.Map<BookDto>(book);
    }

    public BookDetailsDto MapToBookDetailsDto(Book book, IEnumerable<Person> persons)
    {
        var result = mapper.Map<BookDetailsDto>(book);
        result.Authors = bookAuthorMapper.MapToBookAuthorDtoList(persons,book.Authors);
        return result;
    }
}
