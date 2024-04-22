using FluentAssertions;

namespace Library.Demo.Domain.Tests;

public class BookTests
{
    [Fact]
    public void Given_DateOfPurchase_AddBookItem_Should_Add_New_BookItem()
    {
        var dateOfPurchase = DateTime.UtcNow;
        var book = Book.CreateNew();
        book.AddBookItem(dateOfPurchase);

        book.BookItems.Count.Should().Be(1);
        book.BookItems.ToList()[0].DateOfPurchase.Should().Be(dateOfPurchase);
    }
}
