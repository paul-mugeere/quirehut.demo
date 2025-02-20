using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.QueryHandlers;
using QuireHut.Demo.Application.Books.Services;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Tests.Books.QueryHandlers;

public class BooksQueryHandlersTests
{
    private readonly Fixture _fixture;
    private readonly GetBooksQueryHandler _getBooksQueryHandler;
    private readonly GetBookDetailsQueryHandler _detailsQueryHandler;
    private readonly GetBookTitlesQueryHandler _getBookTitlesQueryHandler;
    private readonly IBookQueryService _bookQueryService;

    public BooksQueryHandlersTests()
    {
        _fixture = new Fixture();
        _bookQueryService = A.Fake<IBookQueryService>();
        _getBooksQueryHandler = new GetBooksQueryHandler(_bookQueryService);
        _detailsQueryHandler = new GetBookDetailsQueryHandler(_bookQueryService);
        _getBookTitlesQueryHandler = new GetBookTitlesQueryHandler(_bookQueryService);
    }

    [Fact]
    public async Task GivenNoBooks_HandleGetBooksQuery_ShouldReturnResultWithNoBooks()
    {
        A.CallTo(() => _bookQueryService.GetBooksAsync()).Returns(([]));

        var booksQuery = _fixture.Create<GetBooksQuery>();
        var result = await _getBooksQueryHandler.Handle(booksQuery, CancellationToken.None);

        A.CallTo(() => _bookQueryService.GetBooksAsync()).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.Books.Should().BeEmpty();
    }

    [Fact]
    public async Task GivenBooks_HandleGetBooksQuery_ShouldReturnResultWithBookItems()
    {
        var book = _fixture.Create<BookQueryResult>();

        A.CallTo(()=> _bookQueryService.GetBooksAsync()).Returns(([book]));

        var booksQuery = _fixture.Create<GetBooksQuery>();
        var result = await _getBooksQueryHandler.Handle(booksQuery, CancellationToken.None);

        A.CallTo(() => _bookQueryService.GetBooksAsync()).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.Books.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GivenBooks_HandleGetBookDetailsQuery_ShouldReturnBookDetailsIfBookExists()
    {
        var existingBook = _fixture.Create<BookQueryResult>();

        A.CallTo(() => _bookQueryService.GetBookByIdAsync(A<BookId>._)).Returns((existingBook));

        var bookQuery = new GetBookDetailsQuery(existingBook.BookId);
        var result = await _detailsQueryHandler.Handle(bookQuery, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
        result.Data?.BookId.Should().Be(existingBook.BookId);
    }

    [Fact]
    public async Task GivenBooks_HandleGetBookTitlesQuery_ShouldReturnResultWithBookTitles()
    {
        var books = _fixture.Create<List<BookTitleWithAuthorsQueryResult>>();

        A.CallTo(()=> _bookQueryService.GetBookTitlesWithAuthorsAsync()).Returns(books);

        var query = _fixture.Create<GetBookTitlesQuery>();
        var result = await _getBookTitlesQueryHandler.Handle(query, CancellationToken.None);

        A.CallTo(() => _bookQueryService.GetBookTitlesWithAuthorsAsync()).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.Titles.Should().NotBeEmpty();
    }
}