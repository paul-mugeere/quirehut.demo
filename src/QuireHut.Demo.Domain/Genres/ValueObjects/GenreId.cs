
namespace QuireHut.Demo.Domain.Genres.ValueObjects;

public readonly record struct GenreId(Guid Value)
{
    public static GenreId CreateNew() => new(Guid.NewGuid());
    public static GenreId Empty {get;} = default;
}
