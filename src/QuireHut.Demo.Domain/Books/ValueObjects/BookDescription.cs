namespace QuireHut.Demo.Domain.Books.ValueObjects;

public readonly record struct BookDescription(string Value){
    public static BookDescription Empty{get;} = new BookDescription(string.Empty);
}
