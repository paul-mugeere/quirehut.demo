namespace QuireHut.Demo.Domain.Books.ValueObjects;

public readonly record struct BookAuthorId(Guid Value)
{
    public static BookAuthorId CreateNew() => new(Guid.NewGuid());
    public static BookAuthorId Empty { get; } = default;
}