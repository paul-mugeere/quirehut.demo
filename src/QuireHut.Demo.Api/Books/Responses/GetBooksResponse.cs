using System;

namespace QuireHut.Demo.Api.Contracts.Responses;

public record GetBooksResponse
{
    public IReadOnlyList<BookResponse> Books { get; set; } = [];
    public Pagination Pagination { get; set; } = Pagination.CreateNew(1,1,100);
    public IReadOnlyList<Link> Links { get; set; } = [];

    public static GetBooksResponse CreateNew(IReadOnlyList<BookResponse> books, Pagination pagination, IReadOnlyList<Link> links)
        => new() { Books = books, Pagination = pagination, Links = links };
}
