namespace QuireHut.Demo.Domain.Books.ValueObjects;

public readonly record struct Publisher(string? Name, string? Email="", string? Website=""){
    public static Publisher Empty{get;} = default;

}