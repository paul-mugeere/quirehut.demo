namespace QuireHut.Demo.Domain.Books.ValueObjects;

public readonly record struct Title(string Value){
    public static Title Empty{get;} = new(string.Empty);
    public override string ToString() => Value;
}
