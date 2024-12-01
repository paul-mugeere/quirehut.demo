using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.DTOs.Books.Mappers;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.Repositories;
using QuireHut.Demo.Domain.Persons.Repositories;

namespace QuireHut.Demo.Application.Books.QueryHandlers;

public class GetBookEditionQueryHandler : IRequestHandler<GetBookEditionQuery,Result<BookItemDetails>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IPersonRepository _personRepository;

    public GetBookEditionQueryHandler(IBookRepository bookRepository, IPersonRepository personRepository)
    {
        _bookRepository = bookRepository;
        _personRepository = personRepository;
    }

    public async Task<Result<BookItemDetails>> Handle(GetBookEditionQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await GetBookItemDetailsAsync(request);
            return Result<BookItemDetails>.Success(result);
        }
        catch (Exception e)
        {
            return Result<BookItemDetails>.FromException(e);
        }
    }

    private async Task<BookItemDetails> GetBookItemDetailsAsync(GetBookEditionQuery request)
    {
        var book = await _bookRepository.GetByIdAsync(request.BookId);
        var personIds = book.Authors.Select(d => d.PersonId).ToList();
        var bookEdition = book.Editions.FirstOrDefault(x=>x.Id == request.EditionId);
        var authors = await _personRepository.GetPersonsAsync(personIds);
        var result = new BookItemDetails
        {
            BookId = book.Id.Value,
            Title = book.Title.ToString(),
            Authors = authors.ToAuthorsDtoList(),
            CoverImageUrl = "",
            Edition = bookEdition.ToEditionItemDetails()
        };
        return result;
    }
}