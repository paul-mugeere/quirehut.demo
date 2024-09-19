public readonly record struct AuthorId(Guid Value)
{
    public static AuthorId CreateNew() => new(Guid.NewGuid());
    public static AuthorId Empty { get; } = default;
}