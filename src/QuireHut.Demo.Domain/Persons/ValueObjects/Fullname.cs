namespace QuireHut.Demo.Domain.Persons.ValueObjects;

public record Fullname(string Firstname, string Lastname)
{
    public override string ToString() => $"{Firstname} {Lastname}";
    public static Fullname Empty { get; } = default;
    public static Fullname FromString(string fullname)
    {
        if (string.IsNullOrWhiteSpace(fullname)) return Empty;
        var names = fullname.Trim().Split(' ');
        return new Fullname(names[0], names[1]);
    }

}