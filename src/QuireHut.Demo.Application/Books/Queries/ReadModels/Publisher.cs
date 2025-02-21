namespace QuireHut.Demo.Application.Books.Queries.ReadModels;

public record Publisher(string? Name)
{
    public static Publisher? From(Domain.Books.ValueObjects.Publisher? publisher)
    {
        return publisher == null ? null :  new Publisher(publisher?.Name);
    }
}