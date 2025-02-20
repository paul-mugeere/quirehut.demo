using QuireHut.Demo.Api.Models;

namespace QuireHut.Demo.Api.Responses;

public record BookDetailsResponse
{
    public BookDetails? Details { get; init; }
    private BookDetailsResponse(){}
    public static BookDetailsResponse CreateNew(BookDetails? details) => new() {Details = details };
}