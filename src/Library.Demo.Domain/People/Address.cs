namespace Library.Demo.Domain;

public class Address
{
    public string? Country { get; private set; }
    public string? City { get; private set; }
    public string? State { get; private set; }
    public string? PostCode { get; private set; }
    public string? Street { get; set; }
}
