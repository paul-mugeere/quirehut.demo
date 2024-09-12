public readonly record struct PublisherId(Guid Value){
    public static PublisherId CreateNew() => new(Guid.Empty);
    public static PublisherId Empty{get;} = default;

}