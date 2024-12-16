using FluentAssertions;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.Entities;
using QuireHut.Demo.Domain.Books.Enums;
using QuireHut.Demo.Domain.Books.Exceptions;
using QuireHut.Demo.Domain.Books.ValueObjects;
using QuireHut.Demo.Domain.Genres.ValueObjects;
using QuireHut.Demo.Domain.Persons;
using QuireHut.Demo.Domain.Persons.ValueObjects;

namespace QuireHut.Demo.Domain.Tests.Books;
public class BookTests
{

    [Fact]
    public void CreateNewBook_WithRequiredParameters_ShouldReturnABook()
    {
        // Given
        var title = new Title("some-title");
        var subject = new BookDescription("test-subject");
        var author = Person.CreateNew("test-author", "test-author-2");
        var edition = Edition.CreateNew(new ISBN("test-isbn"), Format.HardPaper, "English",new Publisher("test-publisher"),
            DateTime.Now,  new Dimensions(23, 14, 45), 1000, 200, EditionStatus.Planned);

        // When
        var book = Book.CreateNew(title, subject, [edition], [author.Id]);

        // Then
        book.Should().NotBeNull();
        book.Title.Should().Be(title);
        book.Description.Should().Be(subject);
        book.Editions.Should().NotBeEmpty();
        book.Editions.Should().Contain(x=>x.Id==edition.Id);
    }

    [Fact]
    public void CreateNewBook_WithNoEdition_ShouldThrowAnInvalidBookException()
    {
        // Given
        var isbn = new ISBN("test-isbn");
        var title = new Title("some-title");
        var subject = new BookDescription("test-subject");
        var author = Person.CreateNew("test-author", "test-bibliography");

        // When
        var act = () => Book.CreateNew(title, subject, [], [author.Id]);

        // Then
        act.Should().Throw<InvalidBookException>().Where(x => x.Message.Equals("A book must have at least 1 edition."));

    }

    [Fact]
    public void CreateNewBook_WithNoAuthor_ShouldThrowAnInvalidBookException()
    {
        // Given
        var isbn = new ISBN("test-isbn");
        var title = new Title("some-title");
        var subject = new BookDescription("test-subject");
        var edition = Edition.CreateNew(isbn, Format.HardPaper, "English",new Publisher("test-publisher"), 
            DateTime.Now, new Dimensions(23, 14, 45), 1000, 200, EditionStatus.Planned);

        // When
        var act = () => Book.CreateNew(title, subject, [edition], []);

        // Then
        act.Should().Throw<InvalidBookException>().Where(x => x.Message.Equals("A book must have at least 1 author."));

    }

    [Fact]
    public void AddEdition_ToABook_ShouldIncludeTheNewEditionInTheBookEditions()
    {
        var editionToAdd = Edition.CreateNew(new("test-isbn2"), Format.HardPaper, "test-language",new Publisher("test-publisher"),
            DateTime.Now,  new Dimensions(2, 5, 6), 1000, 200, EditionStatus.Planned);
        var bookEdition = Edition.CreateNew(new("test-isbn1"), Format.AudioBook, "test-language3",new Publisher("test-publisher"),
            DateTime.Now,  new Dimensions(), 1000, 200, EditionStatus.Planned);
        var book = Book.CreateNew(new Title("some-title"), new BookDescription("test-subject"), [bookEdition], [PersonId.CreateNew()]);
        book.AddEdition(editionToAdd);

        book.Editions.Should().Contain(x=>x.Id==editionToAdd.Id);
    }


    [Fact]
    public void AddEdition_ThatHasADuplicateISBN_ShouldThrowAnInvalidBookException()
    {
        var editionToAdd = Edition.CreateNew(new("test-isbn"), Format.HardPaper, "test-language",new Publisher("test-publisher"),
            DateTime.Now,  new Dimensions(2, 5, 6), 1000, 200, EditionStatus.Planned);
        var existingBookEdition = Edition.CreateNew(new("test-isbn"), Format.AudioBook, "test-language3",new Publisher("test-publisher"),
            DateTime.Now,  new Dimensions(), 1000, 200, EditionStatus.Planned);

        var author = Person.CreateNew("test-author", "test-bibliography");
        var book = Book.CreateNew(new Title("some-title"), new BookDescription("test-subject"), [existingBookEdition], [author.Id]);
        var action = () => book.AddEdition(editionToAdd);

        action.Should().Throw<InvalidBookException>().Where(x => x.Message.Equals("A book cannot editions with duplicate ISBN."));
    }

    [Fact]
    public void SetEditionStatus_ofAnExistingEdition_ShouldChangeTheStatusOfTheEdition()
    {
        var statusToUpdateTo = EditionStatus.Published;
        var bookEdition = Edition.CreateNew(
            new("test-isbn1"), 
            Format.AudioBook, 
            "test-language3",
            new Publisher("test-publisher"),
            DateTime.Now, 
            new Dimensions(), 
            1000, 
            200, 
            EditionStatus.Planned);
        var book = Book.CreateNew(new Title("some-title"), new BookDescription("test-subject"), [bookEdition], [PersonId.CreateNew()]);

        book.SetEditionStatus(bookEdition.Id, statusToUpdateTo);

        book.Editions?.FirstOrDefault(e => e.Id == bookEdition.Id)?.Status.Should().Be(statusToUpdateTo);
    }

    [Fact]
    public void UpdatePrice_ofAnExistingEdition_ShouldUpdateThePriceOfTheEdition()
    {
        var priceToUpdateTo = 1000;
        var bookEdition = Edition.CreateNew(
            new("test-isbn1"), 
            Format.AudioBook, 
            "test-language3",
            new Publisher("test-publisher"), 
            DateTime.Now, new Dimensions(), 
            2000, 
            200, 
            EditionStatus.Planned);
        var book = Book.CreateNew(new Title("some-title"), new BookDescription("test-subject"), [bookEdition], [PersonId.CreateNew()]);

        book.UpdatePrice(bookEdition.Id, priceToUpdateTo);

        book.Editions?.FirstOrDefault(e => e.Id == bookEdition.Id)?.Price.Should().Be(priceToUpdateTo);
    }

    [Fact]
    public void UpdateStock_ofAnExistingEdition_ShouldUpdateThePriceOfTheEdition()
    {
        var stockToUpdateTo = 1000;
        var bookEdition = Edition.CreateNew(
            new("test-isbn1"), 
            Format.AudioBook, 
            "test-language3",
            new Publisher("test-publisher"), 
            DateTime.Now, 
            new Dimensions(), 
            2000, 
            200, 
            EditionStatus.Planned);
        var book = Book.CreateNew(new Title("some-title"), new BookDescription("test-subject"), [bookEdition], [PersonId.CreateNew()]);

        book.UpdateStock(bookEdition.Id, stockToUpdateTo);

        book.Editions?.FirstOrDefault(e => e.Id == bookEdition.Id)?.Stock.Should().Be(stockToUpdateTo);
    }

    [Fact]
    public void AddGenre_ToBook_ShouldIncludeTheGenreInTheBookGenres()
    {
        var genreToAdd = GenreId.CreateNew();
        var book = Book.CreateNew(new Title("some-title"), new BookDescription("test-subject"), [Edition.CreateNew(
            new("test-isbn1"), 
            Format.AudioBook, 
            "test-language3",
            new Publisher("test-publisher"), 
            DateTime.Now, 
            new Dimensions(), 
            2000, 
            200, 
            EditionStatus.Planned)], 
            [PersonId.CreateNew()]);

        book.AddGenre(genreToAdd);

        book.Genres.Should().Contain(d=>d.GenreId==genreToAdd);
    }

    [Fact]
    public void AddGenre_ThatAlreadyExists_ShouldThrowAnInvalidBookException()
    {
        var genreToAdd = GenreId.CreateNew();
        var book = Book.CreateNew(
            new Title("some-title"), 
            new BookDescription("test-subject"), 
            [Edition.CreateNew( new("test-isbn1"), 
                Format.AudioBook, "test-language3",
                new Publisher("test-publisher"), 
                DateTime.Now, 
                new Dimensions(), 
                2000, 
                200, 
                EditionStatus.Planned)], 
            [PersonId.CreateNew()]);
        
        book.AddGenre(genreToAdd);

        var action = () => book.AddGenre(genreToAdd);

        action.Should().Throw<InvalidBookException>().Where(x => x.Message.Equals("A book cannot have duplicate genres."));
    }

    [Fact]
    public void RemoveGenre_FromBook_ShouldRemoveTheGenreFromTheBookGenres()
    {
        var genreToRemove = GenreId.CreateNew();
        var book = Book.CreateNew(new Title("some-title"), new BookDescription("test-subject"), [Edition.CreateNew(new("test-isbn1"), Format.AudioBook, "test-language3",new Publisher("test-publisher"),
            DateTime.Now, new Dimensions(), 2000, 200, EditionStatus.Planned)], [PersonId.CreateNew()]);
        book.AddGenre(genreToRemove);

        book.RemoveGenre(genreToRemove);

        book.Genres.Should().NotContain(d=>d.GenreId==genreToRemove);
    }

    [Fact]
    public void RemoveEdition_FromBook_ShouldRemoveTheEditionFromTheBookEditions()
    {
        var editions = new List<Edition> { Edition.CreateNew(
            new("test-isbn2"), 
            Format.AudioBook, 
            "test-language3",
            new Publisher("test-publisher"), 
            DateTime.Now, 
            new Dimensions(), 
            2000, 
            200, 
            EditionStatus.Planned),
            Edition.CreateNew(
                new("test-isbn1"),
                Format.AudioBook,
                "test-language3",
                new Publisher("test-publisher"),
                DateTime.Now,
                new Dimensions(),
                2000,
                200,
                EditionStatus.Planned)
        };
        var book = Book.CreateNew(new Title("some-title"), new BookDescription("test-subject"), editions, [PersonId.CreateNew()]);
        var bookEditionIdToRemove = editions[0].Id;
        book.RemoveEdition(bookEditionIdToRemove);

        book.Editions.Should().NotContain(x=>x.Id==bookEditionIdToRemove);
    }
}
