namespace Library.Demo.Domain;

public record Address
{
    public Guid Id { get; private set; }
    public PersonId PersonId { get; private set; } = PersonId.Empty;
    public Person Person { get; set; } = null!;
    public string Country { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    public string PostCode { get; private set; } = string.Empty;
    public string Street { get; set; } = string.Empty;

    private Address() { }

    public static Address CreateNew(PersonId personId, string country, string city, string state, string postcode, string street)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            PersonId = personId,
            Country = country,
            City = city,
            State = state,
            PostCode = postcode,
            Street = street
        };
    }
}

