using QuireHut.Demo.Api.Models;
using QuireHut.Demo.Api.Shared;
using QuireHut.Demo.Application.Books.DTOs.Books;

namespace QuireHut.Demo.Api.Inventory.Responses;

public record GetBooksResponse
{
    public IReadOnlyList<Book> Books { get; set; } = [];
    public Pagination Pagination { get; set; } = Pagination.CreateNew(1,1,100);
    public IReadOnlyList<Link> Links { get; set; } = [];

    public static GetBooksResponse CreateNew(IReadOnlyList<Book> books, Pagination pagination, IReadOnlyList<Link> links)
        => new() { Books = books, Pagination = pagination, Links = links };
    private GetBooksResponse() { }

    public static GetBooksResponse CreateNew(List<Book> books)=>new() { Books = books };
}