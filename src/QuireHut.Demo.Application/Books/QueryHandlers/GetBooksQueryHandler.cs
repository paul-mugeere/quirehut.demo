using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Mappers;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.Repositories;
using QuireHut.Demo.Domain.Persons;
using QuireHut.Demo.Domain.Persons.Repositories;

namespace QuireHut.Demo.Application.Books.QueryHandlers;

public class GetBooksQueryHandler: IRequestHandler<GetBooksQuery, Result<BookCollectionDto>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IBookMapper _mapper;
    private readonly IBookAuthorMapper _bookAuthorMapper;

    public GetBooksQueryHandler(IBookRepository bookRepository, IPersonRepository personRepository, IBookMapper mapper, IBookAuthorMapper bookAuthorMapper)
    {
        _bookRepository = bookRepository;
        _personRepository = personRepository;
        _mapper = mapper;
        _bookAuthorMapper = bookAuthorMapper;
    }

    public async Task<Result<BookCollectionDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var books = await _bookRepository.GetAllAsync();
            var personIds = books.SelectMany(x => x.Authors.Select(d => d.PersonId).ToHashSet());
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
        var listOfBooks = books.Select(book => MapToBookDto(book, persons)).ToList();
        return BookCollectionDto.CreateNew(listOfBooks);
    }

    private BookDto MapToBookDto(Book book, IEnumerable<Person> persons)
    {
        var bookDto = _mapper.MapToBookDto(book);
        bookDto.Authors = _bookAuthorMapper.MapToBookAuthorDtoList(persons, book.Authors);
        return bookDto;
    }
}