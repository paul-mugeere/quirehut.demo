using QuireHut.Demo.Domain.Books.ValueObjects;
using QuireHut.Demo.Domain.Persons;
using QuireHut.Demo.Domain.Persons.ValueObjects;

namespace QuireHut.Demo.Domain.Books.Entities;

public class BookAuthor
{
    public BookAuthorId Id { get;}
    
    public string? Bibliography { get; } = string.Empty;
    public BookId BookId { get; } = BookId.Empty;
    public Book Book { get; }
    public PersonId PersonId { get; } = PersonId.Empty;
    public Person Person { get; }
    
    private BookAuthor(){}

    private BookAuthor(BookId bookId, PersonId personId)
    {
        Id = BookAuthorId.CreateNew();
        BookId = bookId;
        PersonId = personId;
    }

    public static BookAuthor CreateNew(BookId bookId, PersonId personId)
    {
        return new(bookId, personId);
    }
}