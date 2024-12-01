namespace QuireHut.Demo.Domain.Books.ValueObjects;

public readonly record struct ISBN(string Value){
    public static ISBN Empty{get;} = default;
}
