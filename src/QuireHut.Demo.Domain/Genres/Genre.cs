
using QuireHut.Demo.Domain.Genres.ValueObjects;

namespace QuireHut.Demo.Domain.Genres;

public class Genre
{

    public GenreId Id { get; private set; } = GenreId.Empty;
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; }

    private Genre() { }

    public static Genre CreateNew(string name, string description)
    {
        return new Genre
        {
            Id = GenreId.CreateNew(),
            Name = name,
            Description = description
        };
    }

}
