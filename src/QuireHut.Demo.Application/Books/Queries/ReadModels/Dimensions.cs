namespace QuireHut.Demo.Application.Books.Queries.ReadModels;

public record Dimensions(decimal? Height, decimal? Width, decimal? Depth)
{
    public static Dimensions From(Domain.Books.ValueObjects.Dimensions? dimensions) => new Dimensions(dimensions?.Height,dimensions?.Width, dimensions?.Depth);
}