namespace QuireHut.Demo.Application.Books.DTOs.Books;

public record BookAuthorDto
{
    public Guid Id { get; set; }
    public string? Fullname { get; set; }
}