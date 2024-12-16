using QuireHut.Demo.Api.Models;

namespace QuireHut.Demo.Api.Responses;

public record GetTitlesResponse
{
    public IList<BookTitle> Titles { get; set; }
}