namespace QuireHut.Demo.Application.Books.Queries.ReadModels;

public record BooksCollectionQueryResult
{
    public List<BookWithAuthorsQueryResult> Books { get; init; } = new();

    private BooksCollectionQueryResult(List<BookWithAuthorsQueryResult> titles)
    {
        Books = titles;
    }
    
    public static BooksCollectionQueryResult CreateNew(List<BookWithAuthorsQueryResult> titles) => new (titles);
}