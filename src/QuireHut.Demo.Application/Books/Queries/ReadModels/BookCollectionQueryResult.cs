namespace QuireHut.Demo.Application.Books.Queries.ReadModels;

public record BookListingCollectionQueryResult
{
    public List<BookListingQueryResult> Books { get; init; } = new();

    private BookListingCollectionQueryResult(List<BookListingQueryResult> books)
    {
        Books = books;
    }

    public static BookListingCollectionQueryResult CreateNew(List<BookListingQueryResult> books) => new (books);
}