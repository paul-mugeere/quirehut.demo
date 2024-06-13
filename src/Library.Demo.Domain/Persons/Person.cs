using Microsoft.Win32.SafeHandles;

namespace Library.Demo.Domain;

public record Person
{
    public PersonId Id { get; protected set; } = PersonId.Empty;
    public string? FirstName { get; protected set; }
    public string? LastName { get; protected set; }
    public EmailAddress Email { get; protected set; } = EmailAddress.Empty;
    public string? Phone { get; protected set; }
    public ICollection<Address> Addresses { get;  set; } = [];

    // public IReadOnlyList<Address> ListOfAddresses => Addresses.ToList();
    // public UserAccount? UserAccount { get; protected set; }

    private Person() { }

    public static Person CreateNew(string firstname, string lastname, EmailAddress email, string phone = "")
    {
        return new()
        {
            Id = new(Guid.NewGuid()),
            FirstName = firstname,
            LastName = lastname,
            Email = email,
            Phone = phone
        };

    }

    public void AddAddresses(IEnumerable<Address> addresses)
    {   
        Addresses = [..Addresses, ..addresses];
    }
}
