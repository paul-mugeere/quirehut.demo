using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.QueryHandlers;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.Entities;
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
    private readonly GetBooksQueryHandler _handler;
    private readonly GetBookEditionQueryHandler _editionQueryHandler;

    public BooksQueryHandlersTests()
    {
        _personRepository = A.Fake<IPersonRepository>();
        _bookRepository = A.Fake<IBookRepository>();
        _fixture = new Fixture();
        _handler = new GetBooksQueryHandler(_bookRepository,_personRepository);
        _editionQueryHandler = new GetBookEditionQueryHandler(_bookRepository,_personRepository);
    }

    [Fact]
    public async Task GivenBooks_HandleGetBooksQuery_ShouldReturnResultWithBookItems()
    {
        var books = _fixture.CreateMany<Book>().ToList();
        A.CallTo(() => _bookRepository.GetAllAsync()).Returns(books);
        
        var authors = _fixture.Create<List<Person>>();
        A.CallTo(()=>_personRepository.GetPersonsAsync(A<IEnumerable<PersonId>>._)).Returns(authors);
        
        var booksQuery = _fixture.Create<GetBooksQuery>();
        var result =await _handler.Handle(booksQuery,CancellationToken.None);
        
        A.CallTo(() => _bookRepository.GetAllAsync()).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.Books.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GivenNoBooks_HandleGetBookQuery_ShouldReturnResultWithNoBooks()
    {
        A.CallTo(() => _bookRepository.GetAllAsync()).Returns([]);
        var authors = _fixture.Create<List<Person>>();
        A.CallTo(()=>_personRepository.GetPersonsAsync(A<IEnumerable<PersonId>>._)).Returns(authors);
        
        var booksQuery = _fixture.Create<GetBooksQuery>();
        var result = await _handler.Handle(booksQuery,CancellationToken.None);
        
        A.CallTo(() => _bookRepository.GetAllAsync()).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.Books.Should().BeEmpty();
    }

    [Fact]
    public async Task GivenBooks_HandleGetBookEditionQuery_ShouldReturnBookEditionIfEditionExists()
    {
        var existingBook = _fixture.Create<Book>();
        var existingBookEdition = _fixture.Create<Edition>();
        existingBook.AddEdition(existingBookEdition);
        A.CallTo(()=>_bookRepository.GetByIdAsync(A<BookId>._)).Returns(existingBook);
        
        var bookQuery = new GetBookEditionQuery(existingBook.Id,existingBookEdition.Id);
        var result = await _editionQueryHandler.Handle(bookQuery,CancellationToken.None);
        
        result.IsSuccess.Should().BeTrue();
        result.Data?.Edition.EditionId.Should().Be(existingBookEdition.Id.Value);
        result.Data?.BookId.Should().Be(existingBook.Id.Value);
    }

    [Fact]
    public async Task GivenBooks_HandleGetBookEditionQuery_ShouldReturnBookEditionIfEditionDoesNotExists()
    {
        var existingBook = _fixture.Create<Book>();
        var existingBookEdition = _fixture.Create<Edition>();
        A.CallTo(()=>_bookRepository.GetByIdAsync(A<BookId>._)).Returns(existingBook);
        
        var bookQuery = new GetBookEditionQuery(existingBook.Id,existingBookEdition.Id);
        var result = await _editionQueryHandler.Handle(bookQuery,CancellationToken.None);
        
        result.IsSuccess.Should().BeFalse();
    }
}