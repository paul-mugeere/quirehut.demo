using QuireHut.Demo.Domain;

public readonly record struct Publisher(string Name, string Email, string Website){
    public static Publisher Empty{get;} = default;

}