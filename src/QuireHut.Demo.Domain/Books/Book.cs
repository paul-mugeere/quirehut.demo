
using QuireHut.Demo.Domain.Books.Exceptions;

namespace QuireHut.Demo.Domain;

public class Book
{
    public BookId Id { get; } = BookId.Empty;
    public Title Title { get; } = Title.Empty;
    public Subject Subject { get; } = Subject.Empty;

    private List<GenreId>? _genreIds { get; set; } 
    public IReadOnlyList<GenreId> GenreIds => _genreIds?.AsReadOnly() ?? new List<GenreId>().AsReadOnly();

    private List<Edition> _editions { get; set; } 
    public IReadOnlyList<Edition> Editions => _editions.AsReadOnly();

    private List<AuthorId> _authorIds { get; } 
    public IReadOnlyList<AuthorId> AuthorIds => _authorIds.AsReadOnly();

    public void AddEdition(Edition edition)
    {
        _editions.Add(edition);
        EnsureInvariants();
    }

    public void SetEditionStatus(EditionId editionId, EditionStatus status)
    {
        var edition = TryGetEditionOfId(editionId);
        edition.UpdateStatus(status);
    }

    public void RemoveEdition(EditionId editionId)
    {
        _editions.RemoveAll(e => e.Id == editionId);
    }

    public void UpdatePrice(EditionId editionId, decimal price)
    {
        var edition = TryGetEditionOfId(editionId);
        edition.UpdatePrice(price);
    }

    public void UpdateStock(EditionId editionId, int stock)
    {
        var edition = TryGetEditionOfId(editionId);
        edition.UpdateStock(stock);
    }

    public void AddGenre(GenreId genreId)
    {
        _genreIds ??= [];
        _genreIds.Add(genreId);
        EnsureInvariants();
    }

    public void RemoveGenre(GenreId genreId)
    {
        _genreIds ??= [];
        if (_genreIds.Contains(genreId))
            _genreIds.RemoveAll(id => id == genreId);
    }

    public static Book CreateNew(
        Title title,
        Subject subject,
        List<Edition> editions,
        List<AuthorId> authors) =>
        new(title, subject, editions, authors);

    private Book(
    Title title,
    Subject subject,
    List<Edition> editions,
    List<AuthorId> authors)
    {
        Id = BookId.CreateNew();
        Title = title;
        Subject = subject;
        _authorIds = authors;
        _editions = editions;

        EnsureInvariants();
    }

    private void EnsureInvariants()
    {
        if (HasNoEditions())
            throw new InvalidBookException("A book must have at least 1 edition.");
        if (HasNoAuthors())
            throw new InvalidBookException("A book must have at least 1 author.");
        if (HasDuplicateEditions())
            throw new InvalidBookException("A book cannot editions with duplicate ISBN.");
        if (HasDuplicateGenres())
            throw new InvalidBookException("A book cannot have duplicate genres.");
    }

    private bool HasDuplicateEditions()
    {
        return _editions?.Count() != _editions?.DistinctBy(x => x.ISBN).Count();
    }

    private bool HasNoAuthors() => _authorIds.Count == 0;
    private bool HasNoEditions() => _editions.Count == 0;

    private Edition TryGetEditionOfId(EditionId editionId)
    {
        var editionsDictionary = _editions?.ToDictionary(x => x.Id, x => x) ?? new Dictionary<EditionId, Edition>();
        return editionsDictionary.TryGetValue(editionId, out var edition) ? edition : throw new InvalidOperationException("Edition not found");
    }

    private bool HasDuplicateGenres() => _genreIds?.Count() != _genreIds?.Distinct().Count();


    // For serialization
    private Book() { }

}
