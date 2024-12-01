namespace QuireHut.Demo.Domain.Books.ValueObjects;

public readonly record struct EditionId(Guid Value)
{
    public static EditionId Empty { get; } = default;

    /// <summary>
    /// Creates a new edition id
    /// </summary>
    /// <returns></returns>
    public static EditionId CreateNew() => new EditionId(Guid.NewGuid());

}