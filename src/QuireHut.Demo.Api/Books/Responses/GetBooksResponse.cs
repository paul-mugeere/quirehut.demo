using QuireHut.Demo.Api.Shared;
using QuireHut.Demo.Application.Books.DTOs.Books;

namespace QuireHut.Demo.Api.Books.Responses;

public record GetBooksResponse
{
    public IReadOnlyList<BookItem> Books { get; set; } = [];
    public Pagination Pagination { get; set; } = Pagination.CreateNew(1,1,100);
    public IReadOnlyList<Link> Links { get; set; } = [];

    public static GetBooksResponse CreateNew(IReadOnlyList<BookItem> books, Pagination pagination, IReadOnlyList<Link> links)
        => new() { Books = books, Pagination = pagination, Links = links };
}