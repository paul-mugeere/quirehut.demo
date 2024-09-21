using QuireHut.Demo.Domain;

public class Author{
    public AuthorId Id { get; private set; } = AuthorId.Empty;
    public string Name { get; private set; } = string.Empty;
    public string Bibliography { get; private set; } = string.Empty;

    public static Author CreateNew(string name, string bibliography)
    {
        return new Author
        {
            Id = AuthorId.CreateNew(),
            Name = name,
            Bibliography = bibliography
        };
    }
}
