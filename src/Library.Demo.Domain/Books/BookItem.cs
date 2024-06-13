namespace Library.Demo.Domain;

public record BookItem
{
    public BookItemId Id { get; private set; } = BookItemId.Empty;
    public BookId BookId { get; private set; }
    public BookItemStatus Status { get; private set; }
    public DateTime? DateOfPurchase { get; private set; }
    //public Rack? PlacedAt { get; private set; } //this is for cataloging, more of a call-number

    private BookItem() { }
  
    public static BookItem CreateNew(BookId bookId, DateTime dateOfPurchase, Rack? placedAt=null)
    {
        return new()
        {
            Id = BookItemId.CreateNew(),
            BookId = bookId,
            DateOfPurchase = dateOfPurchase,
            //PlacedAt = placedAt,
        };
    }
}

