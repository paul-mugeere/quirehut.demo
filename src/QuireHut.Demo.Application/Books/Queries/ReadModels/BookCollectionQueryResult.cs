namespace QuireHut.Demo.Application.Books.Queries.ReadModels;

public record BookCollectionQueryResult
{
    public List<BookQueryResult> Books { get; init; } = new();

    private BookCollectionQueryResult(List<BookQueryResult> books)
    {
        Books = books;
    }

    public static BookCollectionQueryResult CreateNew(List<BookQueryResult> books) => new (books);
}