using QuireHut.Demo.Api.Models;

namespace QuireHut.Demo.Api.Responses;

public record BooksResponse
{
    public IList<Book> Books { get; set; }
}