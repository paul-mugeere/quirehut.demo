namespace Library.Demo.Domain;

public record BookItem
{
    public BookItemId Id { get; private set; } = BookItemId.Empty;
    public BookId BookId { get; private set; }
    public BookItemStatus Status { get; private set; }
    public DateTime? DateOfPurchase { get; private set; }
    //public Rack? PlacedAt { get; private set; }

    private BookItem() { }
    public bool Checkout()
    {
        throw new NotImplementedException();
    }
    
    public bool CheckIn()
    {
        throw new NotImplementedException();
    }

    public bool Reserve(){
        throw new NotImplementedException();
    }



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

