using QuireHut.Demo.Domain.Persons.ValueObjects;

namespace QuireHut.Demo.Application.Books.DTOs.Books;

public record BookDto
{
    public Guid BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public List<BookAuthorDto> Authors { get; set; } = new ();
    public List<EditionDto> Editions { get; set; } = new();
}

public record BookAuthorDto
{
    public Guid Id { get; set; }
    public string Fullname { get; set; }
}

public enum EditionItemStatus
{
    Planned =1,
    Published =2,
    OutOfPrint =3,
    Discontinued =4
}
public record PublisherDto(string? Name);
public record DimensionsDto(decimal? Height, decimal? Width, decimal? Depth);
public enum EditionItemFormat
{
    HardPaper = 1,
    PaperBack = 2,
    AudioBook = 3,
    Ebook = 4
}