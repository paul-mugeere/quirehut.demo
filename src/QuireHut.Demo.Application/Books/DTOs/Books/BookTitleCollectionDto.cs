namespace QuireHut.Demo.Application.Books.DTOs.Books;

public record BookTitleCollectionDto
{
    public List<BookTitleDto> Titles { get; init; } = new();

    private BookTitleCollectionDto(List<BookTitleDto> titles)
    {
        Titles = titles;
    }
    
    public static BookTitleCollectionDto CreateNew(List<BookTitleDto> titles) => new (titles);
}