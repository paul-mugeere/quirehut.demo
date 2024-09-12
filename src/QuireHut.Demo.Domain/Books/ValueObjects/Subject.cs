namespace QuireHut.Demo.Domain;

public readonly record struct Subject(string Value){
    public static Subject Empty{get;} = default;
}
