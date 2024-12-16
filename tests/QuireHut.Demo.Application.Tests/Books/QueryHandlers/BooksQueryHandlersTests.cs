using AutoFixture;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Mappers;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.QueryHandlers;
using QuireHut.Demo.Application.Books.Services;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.Entities;
using QuireHut.Demo.Domain.Books.ValueObjects;
using QuireHut.Demo.Domain.Persons;

namespace QuireHut.Demo.Application.Tests.Books.QueryHandlers;

public class BooksQueryHandlersTests
{
    private readonly Fixture _fixture;
    private readonly GetBooksQueryHandler _getBooksQueryHandler;
    private readonly GetBookDetailsQueryHandler _detailsQueryHandler;
     private readonly GetBookTitlesQueryHandler _getBookTitlesQueryHandler;
    private readonly IBookMapper _bookMapper;
    private readonly IBookQueryService _bookQueryService;

    public BooksQueryHandlersTests()
    {
        _fixture = new Fixture();
        _bookQueryService = A.Fake<IBookQueryService>();
        _bookMapper = A.Fake<IBookMapper>();
        _getBooksQueryHandler = new GetBooksQueryHandler(_bookQueryService,_bookMapper,A.Fake<IBookAuthorMapper>());
        _detailsQueryHandler = new GetBookDetailsQueryHandler(_bookQueryService,_bookMapper);
        IBookTitleMapper bookTitleMapper = new BookTitleMapper(new BookAuthorMapper(A.Fake<IMapper>()));
        _getBookTitlesQueryHandler = new GetBookTitlesQueryHandler(bookTitleMapper,_bookQueryService);
    }

    [Fact]
    public async Task GivenNoBooks_HandleGetBooksQuery_ShouldReturnResultWithNoBooks()
    {
        A.CallTo(() => _bookQueryService.GetBooksAsync()).Returns(([],[]));
        
        var booksQuery = _fixture.Create<GetBooksQuery>();
        var result = await _getBooksQueryHandler.Handle(booksQuery,CancellationToken.None);
        
        A.CallTo(() => _bookQueryService.GetBooksAsync()).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.Books.Should().BeEmpty();
    }

    [Fact]
    public async Task GivenBooks_HandleGetBooksQuery_ShouldReturnResultWithBookItems()
    {
        var book = _fixture.Create<Book>();
        var author = _fixture.Create<Person>();
        book.AddAuthor(BookAuthor.CreateNew(book.Id, author.Id));
        
        A.CallTo(()=> _bookQueryService.GetBooksAsync()).Returns(( [book], [author]));

        var booksQuery = _fixture.Create<GetBooksQuery>();
        var result =await _getBooksQueryHandler.Handle(booksQuery,CancellationToken.None);
        
        A.CallTo(() => _bookQueryService.GetBooksAsync()).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.Books.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task GivenBooks_HandleGetBookDetailsQuery_ShouldReturnBookDetailsIfBookExists()
    {
        var existingBook = _fixture.Create<Book>();
        var author = _fixture.Create<Person>();
        existingBook.AddAuthor(BookAuthor.CreateNew(existingBook.Id, author.Id));
        
        A.CallTo(()=> _bookQueryService.GetBookByIdAsync(A<BookId>._)).Returns((existingBook, [author]));
        A.CallTo(() => _bookMapper.MapToBookDetailsDto(A<Book>._, A<List<Person>>._)).Returns(new BookDetailsDto()
        {
            BookId = existingBook.Id.Value
        });

        var bookQuery = new GetBookDetailsQuery(existingBook.Id.Value);
        var result = await _detailsQueryHandler.Handle(bookQuery,CancellationToken.None);
        
        A.CallTo(() => _bookMapper.MapToBookDetailsDto(A<Book>._, A<List<Person>>._)).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.BookId.Should().Be(existingBook.Id.Value);
    }

    [Fact]
    public async Task GivenBooks_HandleGetBookTitlesQuery_ShouldReturnResultWithBookTitles()
    {
        var book = _fixture.Create<Book>();
        var author = _fixture.Create<Person>();
        book.AddAuthor(BookAuthor.CreateNew(book.Id, author.Id));
        
        A.CallTo(()=> _bookQueryService.GetBooksAsync()).Returns(( [book], [author]));

        var query = _fixture.Create<GetBookTitlesQuery>();
        var result = await _getBookTitlesQueryHandler.Handle(query,CancellationToken.None);
        
        A.CallTo(() => _bookQueryService.GetBooksAsync()).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.Titles.Should().NotBeEmpty();
    }
}