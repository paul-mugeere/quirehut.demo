using AutoMapper;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.Entities;
using QuireHut.Demo.Domain.Persons;

namespace QuireHut.Demo.Application.Books.Mappers;

public class BookMappers : IBookMappers
{
    private readonly IMapper _mapper;

    public BookMappers(IMapper mapper)
    {
        _mapper = mapper;
    }

    public List<BookAuthorDto> MapToBookAuthorDtoList(IEnumerable<Person> persons, 
        IReadOnlyList<BookAuthor> bookAuthors)
    {
        var authorIds = bookAuthors.Select(x => x.PersonId.Value).ToList();
        return persons.Where(person=>authorIds.Contains(person.Id.Value)).Select(person=>_mapper.Map<BookAuthorDto>(person)).ToList();
    }

    public BookDto MapToBookDto(Book book)
    {
        return _mapper.Map<BookDto>(book);
    }

    public BookDetailsDto MapToBookDetailsDto(Book book, IEnumerable<Person> persons)
    {
        var result = _mapper.Map<BookDetailsDto>(book);
        result.Authors = MapToBookAuthorDtoList(persons,book.Authors);
        return result;
    }
}

public interface IBookMappers
{
    List<BookAuthorDto> MapToBookAuthorDtoList(IEnumerable<Person> persons,
        IReadOnlyList<BookAuthor> bookAuthors);
    BookDto MapToBookDto(Book book);
    BookDetailsDto MapToBookDetailsDto(Book book, IEnumerable<Person> persons);
}
