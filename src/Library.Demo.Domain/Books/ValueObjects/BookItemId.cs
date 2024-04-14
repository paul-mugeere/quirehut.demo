namespace Library.Demo.Domain;

public readonly record struct BookItemId(Guid Value){
    public static BookItemId Empty{get;} = default;
    public static BookItemId CreateNew() => new(Guid.NewGuid());
}
