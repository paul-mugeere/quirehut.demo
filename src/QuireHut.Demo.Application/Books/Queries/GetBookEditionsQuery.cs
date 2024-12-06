using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.Enums;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Application.Books.Queries;

public record GetBookTitlesQuery() : IRequest<Result<BookTitleCollectionDto>>;

public record BookTitleCollectionDto
{
    public List<BookTitleDto> Titles { get; init; } = new();
}

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

public record BookEditionDetailsDto
{
    
}
