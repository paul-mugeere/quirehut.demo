namespace QuireHut.Demo.Application.Books.DTOs.Books;

public record BookCollectionDto
{
    public List<BookDto> Books { get; init; } = new();
}