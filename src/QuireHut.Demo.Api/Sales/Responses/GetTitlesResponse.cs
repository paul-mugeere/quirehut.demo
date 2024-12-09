using QuireHut.Demo.Api.Models;

namespace QuireHut.Demo.Api.Sales.Responses;

public class GetTitlesResponse
{
    public IList<BookTitle> Titles { get; set; }
}