namespace Library.Demo.Domain;

public record BookItem
{
    public BookItemId Id { get; private set; } = BookItemId.Empty;
     public BookId BookId { get; private set; }
    public Book Book { get; private set; } = null;

    public BookItemStatus Status { get; private set; }
    public DateTime? DateBorrowed { get; private set; }
    public DateTime? DateDue { get; private set; }
    public DateTime? DateOfPurchase { get; private set; }
    public Rack? PlacedAt { get; private set; }

    private BookItem(){}
    public bool Checkout(string memberId)
    {
        throw new NotImplementedException();
    }

    public static BookItem CreateNew(BookId bookId, Rack placedAt){
        return new (){
            Id = BookItemId.CreateNew(),
            BookId = bookId,
            PlacedAt = placedAt
        };
    }
}

