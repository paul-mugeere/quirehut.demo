using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Mappers;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.Services;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books;
using QuireHut.Demo.Domain.Persons;

namespace QuireHut.Demo.Application.Books.QueryHandlers;

public class GetBooksQueryHandler(
    IBookQueryService bookQueryService,
    IBookMapper mapper,
    IBookAuthorMapper bookAuthorMapper)
    : IRequestHandler<GetBooksQuery, Result<BookCollectionDto>>
{
    public async Task<Result<BookCollectionDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var bookTitles = await bookQueryService.GetBooksAsync().ConfigureAwait(false);
            return Result<BookCollectionDto>.Success(MapToBookCollectionDto(bookTitles.books,bookTitles.authors));
        }
        catch (Exception e)
        {
            return Result<BookCollectionDto>.FromException(e);
        }
    }

    private BookCollectionDto MapToBookCollectionDto(List<Book> books, IEnumerable<Person> persons)
    {
        var listOfBooks = books.Select(book => MapToBookDto(book, persons)).ToList();
        return BookCollectionDto.CreateNew(listOfBooks);
    }

    private BookDto MapToBookDto(Book book, IEnumerable<Person> persons)
    {
        var bookDto = mapper.MapToBookDto(book);
        bookDto.Authors = bookAuthorMapper.MapToBookAuthorDtoList(persons, book.Authors);
        return bookDto;
    }
}