using QuireHut.Demo.Application.Books.DTOs.Books;

namespace QuireHut.Demo.Api.Books.Responses;

public record GetBookDetailsResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public EditionItemFormat Format { get;  set;} 
    public EditionItemStatus ItemStatus{get; set;}
    public List<BookItemAuthor> Authors { get; set; } = new ();
    public EditionItemPublisher? Publisher { get; set; } 
    public DateTime? PublicationDate { get;  set;}
}