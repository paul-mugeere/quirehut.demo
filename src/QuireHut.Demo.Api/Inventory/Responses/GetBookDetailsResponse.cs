using QuireHut.Demo.Api.Inventory.Models;

namespace QuireHut.Demo.Api.Inventory.Responses;

public record GetBookDetailsResponse
{
    public BookDetails? Details { get; init; }
    private GetBookDetailsResponse(){}
    public static GetBookDetailsResponse CreateNew(BookDetails? details) => new() {Details = details };
}