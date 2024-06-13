using AutoFixture;
using FakeItEasy;
using Library.Demo.Domain;

namespace Library.Demo.Application.Tests;

public class CreateBookCommandHandlerTests
{
    private readonly IBookRepository _bookRepository;
    private readonly Fixture _fixture;
    private readonly CreateBookCommandHandler _createBookCommand;
    public  CreateBookCommandHandlerTests(){
        _fixture = new Fixture();
        _bookRepository = A.Fake<IBookRepository>();
        _createBookCommand = new CreateBookCommandHandler(_bookRepository);
    }

    [Fact]
    public async Task Handle_WithValidCommand_ShouldSaveBook(){
        var createBookCommand = _fixture.Create<CreateBookCommand>();
        
        await _createBookCommand.Handle(createBookCommand,CancellationToken.None);

        A.CallTo(() => _bookRepository.Save(A<Book>._)).MustHaveHappened();

    }

}
