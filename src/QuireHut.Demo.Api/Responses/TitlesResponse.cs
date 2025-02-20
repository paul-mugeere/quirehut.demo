using QuireHut.Demo.Api.Models;

namespace QuireHut.Demo.Api.Responses;

public record TitlesResponse
{
    public IList<BookTitle> Titles { get; set; }
}