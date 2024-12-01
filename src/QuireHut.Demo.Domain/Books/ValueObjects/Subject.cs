namespace QuireHut.Demo.Domain.Books.ValueObjects;

public readonly record struct Subject(string Value){
    public static Subject Empty{get;} = new Subject(String.Empty);
}
