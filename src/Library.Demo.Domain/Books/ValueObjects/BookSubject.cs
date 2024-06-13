namespace Library.Demo.Domain;

public readonly record struct BookSubject(string Value){
    public static BookSubject Empty{get;} = default;
}