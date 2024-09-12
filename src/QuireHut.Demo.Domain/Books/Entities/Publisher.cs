using QuireHut.Demo.Domain;

public record Publisher{
    public PublisherId Id { get; private set; } = PublisherId.Empty;
    public string Name { get; private set; } = string.Empty;
    public Address Address { get; private set; }
    public string Website { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;

    private List<Book> _books = [];
    public IReadOnlyList<Book> Books => _books.AsReadOnly();

    public Publisher CreateNew(string name, Address address, string website, string email)
    {
        return new Publisher
        {
            Id = PublisherId.CreateNew(),
            Name = name,
            Address = address,
            Website = website,
            Email = email
        };
    }
    
}
