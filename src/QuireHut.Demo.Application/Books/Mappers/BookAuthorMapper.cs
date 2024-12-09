using AutoMapper;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Domain.Books.Entities;
using QuireHut.Demo.Domain.Persons;

namespace QuireHut.Demo.Application.Books.Mappers;

public interface IBookAuthorMapper
{
    List<BookAuthorDto> MapToBookAuthorDtoList(IEnumerable<Person> persons,
        IReadOnlyList<BookAuthor> bookAuthors);
}

public class BookAuthorMapper(IMapper mapper):IBookAuthorMapper
{
    public List<BookAuthorDto> MapToBookAuthorDtoList(IEnumerable<Person> persons, 
        IReadOnlyList<BookAuthor> bookAuthors)
    {
        var authorIds = bookAuthors.Select(x => x.PersonId.Value).ToHashSet();
        return persons.Where(person=>authorIds.Contains(person.Id.Value)).Select(person=>mapper.Map<BookAuthorDto>(person)).ToList();
    }
}