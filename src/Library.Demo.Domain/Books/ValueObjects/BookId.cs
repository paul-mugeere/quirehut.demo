namespace Library.Demo.Domain;

public readonly record struct BookId(Guid Value){
    public static BookId Empty{get;} = default;
    public static BookId CreateNew() => new(Guid.NewGuid());
}