namespace Library.Demo.Domain;

public readonly record struct BookTitle(string Value){
    public static BookTitle Empty{get;} = default;
}
