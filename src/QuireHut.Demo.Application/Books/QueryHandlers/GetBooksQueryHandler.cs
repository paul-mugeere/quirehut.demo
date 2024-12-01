using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.DTOs.Books.Mappers;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.Repositories;
using QuireHut.Demo.Domain.Persons.Repositories;

namespace QuireHut.Demo.Application.Books.QueryHandlers;

public class GetBooksQueryHandler: IRequestHandler<GetBooksQuery, Result<BookItems>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IPersonRepository _personRepository;

    public GetBooksQueryHandler(IBookRepository bookRepository, IPersonRepository personRepository)
    {
        _bookRepository = bookRepository;
        _personRepository = personRepository;
    }

    public async Task<Result<BookItems>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var books = await _bookRepository.GetAllAsync();
            var personIds = books.SelectMany(x => x.Authors.Select(d => d.PersonId).ToList());
            var authors = await _personRepository.GetPersonsAsync(personIds);
            return Result<BookItems>.Success(books.ToBookItems(authors));
        }
        catch (Exception e)
        {
            return Result<BookItems>.FromException(e);
        }
    }
}