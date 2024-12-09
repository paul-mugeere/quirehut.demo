using AutoMapper;
using MediatR;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Mappers;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Common;
using QuireHut.Demo.Domain.Books.Repositories;
using QuireHut.Demo.Domain.Persons.Repositories;

namespace QuireHut.Demo.Application.Books.QueryHandlers;

public class GetBookTitlesQueryHandler : IRequestHandler<GetBookTitlesQuery,Result<BookTitleCollectionDto>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IBookTitleMapper _mapper;
    public GetBookTitlesQueryHandler(IBookRepository bookRepository, IPersonRepository personRepository, IBookTitleMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _personRepository = personRepository;
    }

    public async Task<Result<BookTitleCollectionDto>> Handle(GetBookTitlesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var books = await _bookRepository.GetAllAsync();
            var personIds = books.SelectMany(x => x.Authors.Select(d => d.PersonId).ToList());
            var authors = await _personRepository.GetPersonsAsync(personIds);
            var result = _mapper.MapToBookTitlesDto(books, authors);
            return Result<BookTitleCollectionDto>.Success(result);
        }
        catch (Exception e)
        {
            return Result<BookTitleCollectionDto>.Failure(e.Message);
        }
        
    }
}