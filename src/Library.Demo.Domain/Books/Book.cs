using System.Security.Cryptography.X509Certificates;

namespace Library.Demo.Domain;

public record Book
{
    public BookId Id { get; private set; } = BookId.Empty;
    public ISBN ISBN { get; private set; } = ISBN.Empty;
    public BookTitle Title { get; private set; } = BookTitle.Empty;
    public BookSubject Subject { get; private set; } = BookSubject.Empty;
    public string Publisher { get; private set; } = string.Empty;
    public string Language { get; private set; } = string.Empty;
    public int NumberOfPages { get; private set; }
    public BookFormat BookFormat { get; private set; }

    //These are copies of a book
    public ICollection<BookItem> BookItems { get; private set; } = [];

    private Book() { }

    //ToDo: do we work with BookItemIds or BookItems??
    public void AddBookItem(DateTime dateOfPurchase, Rack? placedAt = null)
    {
        var bookItem = BookItem.CreateNew(Id, dateOfPurchase, placedAt);
        BookItems.Add(bookItem);
    }

    public void RemoveBookItem(BookItemId bookItemId)
    {
        throw new NotImplementedException();
    }

    public bool BorrowBookItem()
    {
        throw new NotImplementedException();
    }

    public bool ReturnBookItem()
    {
        throw new NotImplementedException();
    }

    public bool ReserveBookItem()
    {
        throw new NotImplementedException();
    }

    public static Book CreateNew(
        ISBN ISBN,
        BookTitle title,
        BookSubject subject)
    {
        return new()
        {
            Id = BookId.CreateNew(),
            ISBN = ISBN,
            Title = title,
            Subject = subject
        };
    }

}
