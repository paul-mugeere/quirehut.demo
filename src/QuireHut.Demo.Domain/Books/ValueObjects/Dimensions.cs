namespace QuireHut.Demo.Domain.Books.ValueObjects;

public readonly record struct Dimensions(decimal? Height, decimal? Width, decimal? Depth)
{
    public static Dimensions Empty{get;} = default;

}