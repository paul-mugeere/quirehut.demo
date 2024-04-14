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
    public ICollection<BookAuthor> BookAuthors { get; private set; } = [];
    public ICollection<BookItem> BookItems { get; private set; } = [];

    private Book(){}
    public void AddBookItem(BookItem bookItem){
        BookItems.Add(bookItem);
    }

    public static Book CreateNew()=> new ();
    public static Book CreateNew(string ISBN, string title, string subject, string publisher, string language, int numberOfPages, BookFormat bookFormat, ICollection<BookAuthor> authors)
    {
        return new ()
        {
            Id = BookId.CreateNew(),
            ISBN = ISBN,
            Title = title,
            Subject = subject,
            Publisher = publisher,
            Language = language,
            NumberOfPages = numberOfPages,
            BookFormat = bookFormat,
            BookAuthors = authors,
        };
    }

}

