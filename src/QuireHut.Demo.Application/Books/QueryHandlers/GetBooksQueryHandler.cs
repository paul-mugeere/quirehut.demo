using AutoMapper;
using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Mappers;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.Entities;
using QuireHut.Demo.Domain.Books.Repositories;
using QuireHut.Demo.Domain.Persons;
using QuireHut.Demo.Domain.Persons.Repositories;

namespace QuireHut.Demo.Application.Books.QueryHandlers;

public class GetBooksQueryHandler: IRequestHandler<GetBooksQuery, Result<BookCollectionDto>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IBookMappers _mappers;

    public GetBooksQueryHandler(IBookRepository bookRepository, IPersonRepository personRepository, IBookMappers mappers)
    {
        _bookRepository = bookRepository;
        _personRepository = personRepository;
        _mappers = mappers;
    }

    public async Task<Result<BookCollectionDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var books = await _bookRepository.GetAllAsync();
            var personIds = books.SelectMany(x => x.Authors.Select(d => d.PersonId).ToList());
            var authors = await _personRepository.GetPersonsAsync(personIds);
            return Result<BookCollectionDto>.Success(MapToBookCollectionDto(books,authors));
        }
        catch (Exception e)
        {
            return Result<BookCollectionDto>.FromException(e);
        }
    }

    private BookCollectionDto MapToBookCollectionDto(List<Book> books, IEnumerable<Person> persons)
    {
        return new BookCollectionDto
        {
            Books = books.Select(book =>
            {
                var bookDto = _mappers.MapToBookDto(book);
                bookDto.Authors = _mappers.MapToBookAuthorDtoList(persons, book.Authors);
                return bookDto;
            }).ToList()
        };
    }

   
}