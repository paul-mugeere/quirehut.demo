using QuireHut.Demo.Api.Models;

namespace QuireHut.Demo.Api.Responses;

public record GetBookDetailsResponse
{
    public BookDetails? Details { get; init; }
    private GetBookDetailsResponse(){}
    public static GetBookDetailsResponse CreateNew(BookDetails? details) => new() {Details = details };
}