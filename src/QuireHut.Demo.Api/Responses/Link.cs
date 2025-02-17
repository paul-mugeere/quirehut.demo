namespace QuireHut.Demo.Api.Responses;

/// <summary>
/// Allows for including related actions or resources in the response
/// </summary>
public record Link
{
    public string Href { get; set; } = string.Empty;
    public string Rel { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
}
