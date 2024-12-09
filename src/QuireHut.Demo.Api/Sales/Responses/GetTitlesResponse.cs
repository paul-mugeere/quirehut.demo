using QuireHut.Demo.Api.Models;

namespace QuireHut.Demo.Api.Sales.Responses;

public class GetTitlesResponse
{
    public IList<BookListing> Books { get; set; }
}