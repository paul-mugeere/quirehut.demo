namespace Library.Demo.Domain;

public class Book
{
    public BookId Id { get; private set; } = BookId.Empty;
    public string ISBN { get; private set; } = string.Empty;
    public string Title { get; private set; } = string.Empty;
    public string Subject { get; private set; } = string.Empty;
    public string Publisher { get; private set; } = string.Empty;
    public string Language { get; private set; } = string.Empty;
    public int NumberOfPages { get; private set; }
    public BookFormat BookFormat { get; private set; }
    public BookStatus Status { get; private set; }
    public ICollection<BookAuthor> Authors { get; private set; } = [];

    #region might need revision, do they belong here?
    public DateTime? DateBorrowed { get; private set; }
    public DateTime? DateDue { get; private set; }
    public DateTime? DateOfPurchase { get; private set; }
    public Rack? PlacedAt { get; private set; }
    #endregion


    public bool Checkout(string memberId)
    {
        throw new NotImplementedException();
    }
}

