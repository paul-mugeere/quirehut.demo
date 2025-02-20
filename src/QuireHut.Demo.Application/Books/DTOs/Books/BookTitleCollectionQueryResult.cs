namespace QuireHut.Demo.Application.Books.DTOs.Books;

public record BookTitleCollectionQueryResult
{
    public List<BookTitleWithAuthorsQueryResult> Titles { get; init; } = new();

    private BookTitleCollectionQueryResult(List<BookTitleWithAuthorsQueryResult> titles)
    {
        Titles = titles;
    }
    
    public static BookTitleCollectionQueryResult CreateNew(List<BookTitleWithAuthorsQueryResult> titles) => new (titles);
}