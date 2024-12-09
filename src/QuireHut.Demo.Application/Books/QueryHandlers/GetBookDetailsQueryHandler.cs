using AutoMapper;
using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Mappers;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.Repositories;
using QuireHut.Demo.Domain.Persons.Repositories;

namespace QuireHut.Demo.Application.Books.QueryHandlers;

public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery,Result<BookDetailsDto>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IBookMapper _bookMapper;
    public GetBookDetailsQueryHandler(IBookRepository bookRepository, IPersonRepository personRepository, IBookMapper bookMapper)
    {
        _bookRepository = bookRepository;
        _personRepository = personRepository;
        _bookMapper = bookMapper;
    }

    public async Task<Result<BookDetailsDto>> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await GetBookItemDetailsAsync(request);
            return Result<BookDetailsDto>.Success(result);
        }
        catch (Exception e)
        {
            return Result<BookDetailsDto>.FromException(e);
        }
    }

    private async Task<BookDetailsDto> GetBookItemDetailsAsync(GetBookDetailsQuery request)
    {
        var book = await _bookRepository.GetByIdAsync(request.BookId);
        var personIds = book.Authors.Select(d => d.PersonId).ToList();
        var persons = await _personRepository.GetPersonsAsync(personIds);
        return _bookMapper.MapToBookDetailsDto(book,persons);;
    }
}