namespace Library.Demo.Domain;

public readonly record struct ISBN(string Value){
    public static ISBN Empty{get;} = default;
}
