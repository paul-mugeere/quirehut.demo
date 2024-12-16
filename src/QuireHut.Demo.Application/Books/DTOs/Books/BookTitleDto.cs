using QuireHut.Demo.Domain.Books.Enums;

namespace QuireHut.Demo.Application.Books.DTOs.Books;

public record BookTitleDto
{
    public Guid EditionId { get; set; }
    public Guid BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public List<BookAuthorDto> Authors { get; set; } = new ();
    public Format Format { get;  set;}
    public decimal Price { get;  set; }
    public DateTime? PublicationDate { get;  set;}
    public string Language { get;  set;} = string.Empty;
}