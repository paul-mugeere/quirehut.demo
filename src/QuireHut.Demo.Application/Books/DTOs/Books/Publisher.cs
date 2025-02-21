namespace QuireHut.Demo.Application.Books.DTOs.Books;

public record Publisher(string? Name)
{
    public static Publisher? From(Domain.Books.ValueObjects.Publisher? publisher)
    {
        return publisher == null ? null :  new Publisher(publisher?.Name);
    }
}