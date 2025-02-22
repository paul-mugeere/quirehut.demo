using QuireHut.Demo.Api.Models;

namespace QuireHut.Demo.Api.Responses;

public record BookListingCollectionResponse
{
    public IReadOnlyList<BookListing> Books { get; set; } = [];
    public Pagination Pagination { get; set; } = Pagination.CreateNew(1,1,100);
    public IReadOnlyList<Link> Links { get; set; } = [];

    public static BookListingCollectionResponse CreateNew(IReadOnlyList<BookListing> books, Pagination pagination, IReadOnlyList<Link> links)
        => new() { Books = books, Pagination = pagination, Links = links };
    private BookListingCollectionResponse() { }

    public static BookListingCollectionResponse CreateNew(List<BookListing> books)=>new() { Books = books };
}