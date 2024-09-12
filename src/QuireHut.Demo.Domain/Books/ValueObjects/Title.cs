namespace QuireHut.Demo.Domain;

public readonly record struct Title(string Value){
    public static Title Empty{get;} = default;
}
