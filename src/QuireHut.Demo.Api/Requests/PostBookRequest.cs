namespace QuireHut.Demo.Api.Requests;

public record PostBookRequest(
    string Title,
    string Subject,
    List<Guid> AuthorIds,
    List<PostBookEdition> Editions
);