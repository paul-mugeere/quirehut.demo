using QuireHut.Demo.Api.Models;

namespace QuireHut.Demo.Api.Responses;

public record BookListingDetailsResponse
{
    public BookListing? Details { get; init; }
    private BookListingDetailsResponse(){}
    public static BookListingDetailsResponse CreateNew(BookListing? details) => new() {Details = details };
}