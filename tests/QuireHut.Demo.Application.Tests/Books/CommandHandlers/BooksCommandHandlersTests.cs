using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using QuireHut.Demo.Application.Books.CommandHandlers;
using QuireHut.Demo.Application.Books.Commands;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.Repositories;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Tests.Books.CommandHandlers;

public class BooksCommandHandlersTests
{
    private readonly IBookRepository _bookRepository;
    private readonly Fixture _fixture;
    private readonly CreateBookCommandHandler _createBookCommandHandler;
    public  BooksCommandHandlersTests(){
        _fixture = new Fixture();
        _bookRepository = A.Fake<IBookRepository>();
        _createBookCommandHandler = new CreateBookCommandHandler(_bookRepository);
    }

    [Fact]
    public async Task Handle_CreateBookCommand_ShouldSaveBook(){
        var createBookCommand = _fixture.Create<CreateBookCommand>();
        var bookId = _fixture.Create<BookId>();
        A.CallTo(() => _bookRepository.SaveAsync(A<Book>._)).Returns(bookId);
        
        var bookIdResult =await _createBookCommandHandler.Handle(createBookCommand,CancellationToken.None);

        A.CallTo(() => _bookRepository.SaveAsync(A<Book>._)).MustHaveHappened();
        bookIdResult.Data.Should().NotBe(BookId.Empty.Value);
        bookIdResult.Data.Should().Be(bookId.Value);
    }
}
