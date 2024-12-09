using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Mappers;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.QueryHandlers;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.Repositories;
using QuireHut.Demo.Domain.Books.ValueObjects;
using QuireHut.Demo.Domain.Persons;
using QuireHut.Demo.Domain.Persons.Repositories;
using QuireHut.Demo.Domain.Persons.ValueObjects;

namespace QuireHut.Demo.Application.Tests.Books.QueryHandlers;

public class BooksQueryHandlersTests
{
    private readonly IBookRepository _bookRepository;
    private readonly IPersonRepository _personRepository;
    private readonly Fixture _fixture;
    private readonly GetBooksQueryHandler _getBooksQueryHandler;
    private readonly GetBookDetailsQueryHandler _detailsQueryHandler;
     private readonly GetBookTitlesQueryHandler _getBookTitlesQueryHandler;
    private readonly IBookMapper _mapper;
    private readonly IBookTitleMapper _bookTitleMapper;
    private readonly IBookAuthorMapper _bookAuthorMapper;

    public BooksQueryHandlersTests()
    {
        _personRepository = A.Fake<IPersonRepository>();
        _bookRepository = A.Fake<IBookRepository>();
        _mapper = A.Fake<IBookMapper>();
        _bookTitleMapper = A.Fake<IBookTitleMapper>();
        _bookAuthorMapper = A.Fake<IBookAuthorMapper>();
        _fixture = new Fixture();
        _getBooksQueryHandler = new GetBooksQueryHandler(_bookRepository,_personRepository,_mapper,_bookAuthorMapper);
        _detailsQueryHandler = new GetBookDetailsQueryHandler(_bookRepository,_personRepository,_mapper);
        _getBookTitlesQueryHandler = new GetBookTitlesQueryHandler(_bookRepository,_personRepository,_bookTitleMapper);
    }

    [Fact]
    public async Task GivenBooks_HandleGetBooksQuery_ShouldReturnResultWithBookItems()
    {
        var authors = _fixture.CreateMany<Person>(3);
        A.CallTo(()=>_personRepository.GetPersonsAsync(A<IEnumerable<PersonId>>._)).Returns(authors);
        
        var books = _fixture.CreateMany<Book>().ToList();
        A.CallTo(() => _bookRepository.GetAllAsync()).Returns(books);

        var booksQuery = _fixture.Create<GetBooksQuery>();
        var result =await _getBooksQueryHandler.Handle(booksQuery,CancellationToken.None);
        
        A.CallTo(() => _bookRepository.GetAllAsync()).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.Books.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GivenNoBooks_HandleGetBooksQuery_ShouldReturnResultWithNoBooks()
    {
        A.CallTo(() => _bookRepository.GetAllAsync()).Returns([]);
        var authors = _fixture.Create<List<Person>>();
        A.CallTo(()=>_personRepository.GetPersonsAsync(A<IEnumerable<PersonId>>._)).Returns(authors);
        
        var booksQuery = _fixture.Create<GetBooksQuery>();
        var result = await _getBooksQueryHandler.Handle(booksQuery,CancellationToken.None);
        
        A.CallTo(() => _bookRepository.GetAllAsync()).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.Books.Should().BeEmpty();
    }

    [Fact]
    public async Task GivenBooks_HandleGetBookDetailsQuery_ShouldReturnBookDetailsIfBookExists()
    {
        var authors = _fixture.Create<List<Person>>();
        A.CallTo(()=>_personRepository.GetPersonsAsync(A<IEnumerable<PersonId>>._)).Returns(authors);
        
        var existingBook = _fixture.Create<Book>();
        A.CallTo(()=>_bookRepository.GetByIdAsync(A<BookId>._)).Returns(existingBook);
        A.CallTo(() => _mapper.MapToBookDetailsDto(A<Book>._, A<List<Person>>._)).Returns(new BookDetailsDto()
        {
            BookId = existingBook.Id.Value
        });

        var bookQuery = new GetBookDetailsQuery(existingBook.Id);
        var result = await _detailsQueryHandler.Handle(bookQuery,CancellationToken.None);
        
        A.CallTo(() => _mapper.MapToBookDetailsDto(A<Book>._, A<List<Person>>._)).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.BookId.Should().Be(existingBook.Id.Value);
    }

    [Fact]
    public async Task GivenBooks_HandleGetBookTitlesQuery_ShouldReturnResultWithBookTitles()
    {
        var authors = _fixture.Create<List<Person>>();
        A.CallTo(()=>_personRepository.GetPersonsAsync(A<IEnumerable<PersonId>>._)).Returns(authors);
        
        var allBooks = _fixture.Create<List<Book>>();
        A.CallTo(() => _bookRepository.GetAllAsync()).Returns(allBooks);

        var query = _fixture.Create<GetBookTitlesQuery>();
        var result = await _getBookTitlesQueryHandler.Handle(query,CancellationToken.None);
        
        A.CallTo(() => _bookRepository.GetAllAsync()).MustHaveHappened();
        A.CallTo(() => _personRepository.GetPersonsAsync(A<IEnumerable<PersonId>>._)).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.Titles.Should().NotBeEmpty();
    }
}