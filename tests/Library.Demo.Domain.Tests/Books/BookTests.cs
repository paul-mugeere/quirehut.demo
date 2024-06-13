using FluentAssertions;

namespace Library.Demo.Domain.Tests;

public class BookTests
{
    [Fact]
    public void Given_Book_details_Should_Create_New_Book()
    {
        string isbn = "isbn";
        string title = "title";
        string subject = "subject";

        var book = Book.CreateNew(new ISBN(isbn), new BookTitle(title), new BookSubject(subject));

        book.ISBN.Value.Should().Be(isbn);
        book.Title.Value.Should().Be(title);
        book.Subject.Value.Should().Be(subject);
        book.BookItems.Count().Should().Be(0);
    }

    [Fact]
    public void Given_DateOfPurchase_AddBookItem_Should_Add_New_BookItem()
    {
        var dateOfPurchase = DateTime.UtcNow;
        var book = Book.CreateNew(new ISBN("test-isbn"), new BookTitle("some-title"), new BookSubject("test-subject"));
        book.AddBookItem(dateOfPurchase);

        book.BookItems.Count.Should().Be(1);
        book.BookItems.ToList()[0].DateOfPurchase.Should().Be(dateOfPurchase);
    }
}
