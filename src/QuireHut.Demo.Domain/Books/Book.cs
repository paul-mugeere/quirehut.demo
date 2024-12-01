using QuireHut.Demo.Domain.Books.Entities;
using QuireHut.Demo.Domain.Books.Enums;
using QuireHut.Demo.Domain.Books.Exceptions;
using QuireHut.Demo.Domain.Books.ValueObjects;
using QuireHut.Demo.Domain.Genres.ValueObjects;
using QuireHut.Demo.Domain.Persons.ValueObjects;

namespace QuireHut.Demo.Domain.Books;

public class Book
{
    public BookId Id { get; } = BookId.Empty;
    public Title Title { get; } = Title.Empty;
    public Subject Subject { get; } = Subject.Empty;

    private readonly List<BookGenre> _genres  = new();
    public IReadOnlyList<BookGenre> Genres => _genres.AsReadOnly();
    
    private readonly List<Edition> _editions  = new();
    public IReadOnlyList<Edition> Editions => _editions.AsReadOnly();
    
    private readonly List<BookAuthor> _authors  = new ();
    public IReadOnlyList<BookAuthor> Authors => _authors.AsReadOnly();

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
        _genres.Add(BookGenre.CreateNew(Id,genreId));
        EnsureInvariants();
    }

    public void RemoveGenre(GenreId genreId)
    {
        if (ContainsGenre(genreId))
            _genres.RemoveAll(id => id.GenreId == genreId);
    }

    public static Book CreateNew(
        Title title,
        Subject subject,
        List<Edition> editions,
        List<PersonId> authors) =>
        new(title, subject, editions, authors);

    private Book(
    Title title,
    Subject subject,
    List<Edition> editionsCollection,
    List<PersonId> authors)
    {
        Id = BookId.CreateNew();
        Title = title;
        Subject = subject;
        _authors = authors?.Select(x=> BookAuthor.CreateNew(Id, x)).ToList()??[];
        _editions = editionsCollection;

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

    private bool HasDuplicateGenres() =>
        _genres.Count > _genres.DistinctBy(x => x.GenreId).Count();

    private bool HasDuplicateEditions()
    {
        return _editions.Count() != _editions.DistinctBy(x => x.ISBN).Count();
    }

    private bool HasNoAuthors() => _authors.Count == 0;
    private bool HasNoEditions() => _editions.Count == 0;

    private Edition TryGetEditionOfId(EditionId editionId)
    {
        var editionsDictionary = _editions.ToDictionary(x => x.Id, x => x);
        return editionsDictionary.TryGetValue(editionId, out var edition) ? edition : throw new InvalidOperationException("Edition not found");
    }
    
    private bool ContainsGenre(GenreId genreId)
    {
        return _genres.Any(bookGenre => bookGenre.GenreId == genreId);
    }

    // For serialization
    private Book() { }

}
