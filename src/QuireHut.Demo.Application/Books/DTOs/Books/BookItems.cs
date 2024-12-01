namespace QuireHut.Demo.Application.Books.DTOs.Books;

public record BookItems
{
    public List<BookItem> Books { get; init; } = new();
}