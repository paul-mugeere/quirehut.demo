namespace Library.Demo.Domain;

public record Book
{
    public BookId Id { get; private set; } = BookId.Empty;
    public string ISBN { get; private set; } = string.Empty;
    public string Title { get; private set; } = string.Empty;
    public string Subject { get; private set; } = string.Empty;
    public string Publisher { get; private set; } = string.Empty;
    public string Language { get; private set; } = string.Empty;
    public int NumberOfPages { get; private set; }
    public BookFormat BookFormat { get; private set; }

    //These are copies of a book
    public ICollection<BookItem> BookItems { get; private set; } = [];

    private Book() { }

    //ToDo: do we work with BookItemIds or BookItems??
    public void AddBookItem(DateTime dateOfPurchase, Rack? placedAt =null)
    {
        var bookItem = BookItem.CreateNew(Id, dateOfPurchase, placedAt);
        BookItems.Add(bookItem);
    }

    public void RemoveBookItem(BookItemId bookItemId){
        throw new NotImplementedException();
    }

    public static Book CreateNew() => new();
    public static Book CreateNew(string ISBN, string title, string language, int numberOfPages)
    {
        return new()
        {
            Id = BookId.CreateNew(),
            ISBN = ISBN,
            Title = title,
            Language = language,
            NumberOfPages = numberOfPages
        };
    }

}

public record BookLoan{
    
    public DateTime? DateBorrowed { get; private set; } // this is an aspect of BookLoan
    public DateTime? DateDue { get; private set; } // this is an aspect of BookLoan
    
    public void CheckoutBookItem(PersonId personId, BookItemId bookItemId){
        throw new NotImplementedException();
    }

}

