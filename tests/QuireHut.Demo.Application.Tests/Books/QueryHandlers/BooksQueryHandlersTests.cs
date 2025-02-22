using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.Queries.QueryHandlers;
using QuireHut.Demo.Application.Books.Queries.ReadModels;
using QuireHut.Demo.Application.Books.Queries.Services;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Tests.Books.QueryHandlers;

public class BooksQueryHandlersTests
{
    private readonly Fixture _fixture;
    private readonly GetBookListingsQueryQueryHandler _getBooksQueryHandler;
    private readonly GetBookListingDetailsQueryHandler _detailsQueryHandler;
    private readonly GetBooksQueryHandler _getBookTitlesQueryHandler;
    private readonly IBookQueryService _bookQueryService;

    public BooksQueryHandlersTests()
    {
        _fixture = new Fixture();
        _bookQueryService = A.Fake<IBookQueryService>();
        _getBooksQueryHandler = new GetBookListingsQueryQueryHandler(_bookQueryService);
        _detailsQueryHandler = new GetBookListingDetailsQueryHandler(_bookQueryService);
        _getBookTitlesQueryHandler = new GetBooksQueryHandler(_bookQueryService);
    }

    [Fact]
    public async Task GivenNoBooks_HandleGetBooksQuery_ShouldReturnResultWithNoBooks()
    {
        A.CallTo(() => _bookQueryService.GetBookListings()).Returns(([]));

        var booksQuery = _fixture.Create<GetBookListingsQuery>();
        var result = await _getBooksQueryHandler.Handle(booksQuery, CancellationToken.None);

        A.CallTo(() => _bookQueryService.GetBookListings()).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.Books.Should().BeEmpty();
    }

    [Fact]
    public async Task GivenBooks_HandleGetBooksQuery_ShouldReturnResultWithBookItems()
    {
        var book = _fixture.Create<BookListingQueryResult>();

        A.CallTo(()=> _bookQueryService.GetBookListings()).Returns(([book]));

        var booksQuery = _fixture.Create<GetBookListingsQuery>();
        var result = await _getBooksQueryHandler.Handle(booksQuery, CancellationToken.None);

        A.CallTo(() => _bookQueryService.GetBookListings()).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.Books.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GivenBooks_HandleGetBookDetailsQuery_ShouldReturnBookDetailsIfBookExists()
    {
        var existingBook = _fixture.Create<BookListingQueryResult>();

        A.CallTo(() => _bookQueryService.GetBookListingById(A<BookId>._)).Returns((existingBook));

        var bookQuery = new GetBookListingDetailsQuery(existingBook.BookId);
        var result = await _detailsQueryHandler.Handle(bookQuery, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
        result.Data?.BookId.Should().Be(existingBook.BookId);
    }

    [Fact]
    public async Task GivenBooks_HandleGetBookTitlesQuery_ShouldReturnResultWithBookTitles()
    {
        var books = _fixture.Create<List<BookWithAuthorsQueryResult>>();

        A.CallTo(()=> _bookQueryService.GetBooksWithAuthors()).Returns(books);

        var query = _fixture.Create<GetBooksQuery>();
        var result = await _getBookTitlesQueryHandler.Handle(query, CancellationToken.None);

        A.CallTo(() => _bookQueryService.GetBooksWithAuthors()).MustHaveHappened();
        result.IsSuccess.Should().BeTrue();
        result.Data?.Books.Should().NotBeEmpty();
    }
}