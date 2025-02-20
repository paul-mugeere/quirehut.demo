using QuireHut.Demo.Api.Models;

namespace QuireHut.Demo.Api.Responses;

public record BooksCollectionResponse
{
    public IReadOnlyList<Book> Books { get; set; } = [];
    public Pagination Pagination { get; set; } = Pagination.CreateNew(1,1,100);
    public IReadOnlyList<Link> Links { get; set; } = [];

    public static BooksCollectionResponse CreateNew(IReadOnlyList<Book> books, Pagination pagination, IReadOnlyList<Link> links)
        => new() { Books = books, Pagination = pagination, Links = links };
    private BooksCollectionResponse() { }

    public static BooksCollectionResponse CreateNew(List<Book> books)=>new() { Books = books };
}