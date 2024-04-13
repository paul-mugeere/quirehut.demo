namespace Library.Demo.Domain;

public class BookItem
{
    public Book Book { get; private set; } = Book.CreateNew();
    public BookItemStatus Status { get; private set; }
    public DateTime? DateBorrowed { get; private set; }
    public DateTime? DateDue { get; private set; }
    public DateTime? DateOfPurchase { get; private set; }
    public Rack? PlacedAt { get; private set; }

    public bool Checkout(string memberId)
    {
        throw new NotImplementedException();
    }
}

