namespace QuireHut.Demo.Api.Requests;

public record CreateBook(
    string Title,
    string Subject,
    List<Guid> AuthorIds,
    List<CreateBookEdition> Editions
);