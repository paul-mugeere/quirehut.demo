using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Books.Entities;
using QuireHut.Demo.Domain.Persons;

namespace QuireHut.Demo.Application.Books.DTOs.Books.Mappers;

public static class BookMapper
{
    public static BookItems ToBookItems(this List<Book> books, IEnumerable<Person> persons)
    {
        return new BookItems()
        {
            Books = books.SelectMany(book => book.Editions.Select(
                edition => new BookItem
                {
                    BookId = book.Id.Value,
                    EditionId = edition.Id.Value,
                    Title = book.Title.Value,
                    Authors  = persons.ToAuthorsDtoList(),
                    Price = edition.Price,
                    PublicationDate = edition.PublicationDate,
                    Format = (EditionItemFormat)edition.Format,
                    Language = edition.Language
                }).ToList()).ToList(),
        };
    }

    public static List<BookItemAuthor> ToAuthorsDtoList(this IEnumerable<Person> persons)
    {
        return persons?.Select(person=>new BookItemAuthor()
        {
            Fullname = person.Fullname.ToString(),
        }).ToList()??[];
    }
    
    public static EditionItemDetails ToEditionItemDetails(this Edition bookEdition)
    {
        return new EditionItemDetails()
        {
            EditionId = bookEdition.Id.Value,
            ISBN = bookEdition.ISBN.Value,
            Dimensions = 
                new EditionItemDimensions(bookEdition.Dimensions.Value.Height, bookEdition.Dimensions.Value.Width,bookEdition.Dimensions.Value.Depth),
            Format = (EditionItemFormat)bookEdition.Format,
            Language = bookEdition.Language,
            Price = bookEdition.Price,
            Publisher = new EditionItemPublisher(bookEdition?.Publisher?.Name),
            Stock =  bookEdition?.Stock ?? 0,
            NumberOfPages = bookEdition?.NumberOfPages ?? 0,
            Status = (EditionItemStatus)bookEdition.Status,
            PublicationDate = bookEdition.PublicationDate,
        };
    }
}