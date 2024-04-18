namespace Library.Demo.Domain;

public readonly record struct PersonId(Guid Value){
    public static PersonId Empty { get; } = default;
}

