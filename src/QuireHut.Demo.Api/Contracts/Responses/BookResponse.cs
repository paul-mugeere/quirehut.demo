namespace QuireHut.Demo.Api.Contracts.Responses;

public record BookResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public IReadOnlyList<string> Genres { get; set; }
    public decimal Price { get; set; }
    public DateTime? PublicationDate { get; set; }
    public string CoverImageUrl { get; set; }
    public double AverageRating { get; set; }
} 
