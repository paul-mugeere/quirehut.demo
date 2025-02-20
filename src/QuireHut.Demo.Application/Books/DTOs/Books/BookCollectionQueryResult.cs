namespace QuireHut.Demo.Application.Books.DTOs.Books;

public record BookCollectionQueryResult
{
    public List<BookQueryResult> Books { get; init; } = new();

    private BookCollectionQueryResult(List<BookQueryResult> books)
    {
        Books = books;
    }

    public static BookCollectionQueryResult CreateNew(List<BookQueryResult> books) => new (books);
}