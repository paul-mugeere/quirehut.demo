using QuireHut.Demo.Domain;

public readonly record struct Publisher(string Name, Address Address, string Website, string Email){
    public static Publisher Empty{get;} = default;
}