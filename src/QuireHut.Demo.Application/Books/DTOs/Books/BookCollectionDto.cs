namespace QuireHut.Demo.Application.Books.DTOs.Books;

public record BookCollectionDto
{
    public List<BookDto> Books { get; init; } = new();

    private BookCollectionDto(List<BookDto> books)
    {
        Books = books;
    }

    public static BookCollectionDto CreateNew(List<BookDto> books) => new (books);
}