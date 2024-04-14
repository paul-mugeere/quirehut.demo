namespace Library.Demo.Domain;

public class BookAuthor
{
    public Guid Id{ get; private set; } 
    public PersonId PersonId{ get; private set; } = PersonId.Empty;
    public Person? Person{ get; private set; }
    public BookId BookId { get; private set; } = BookId.Empty;
    public Book? Book { get; private set;}
    
    public static BookAuthor CreateNew(BookId bookId, PersonId personId){
        return new (){Id = Guid.NewGuid(), PersonId = personId, BookId = bookId};
    }
}
