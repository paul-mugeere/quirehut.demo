using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuireHut.Demo.Api.Inventory.Mappers;
using QuireHut.Demo.Api.Inventory.Models;
using QuireHut.Demo.Api.Inventory.Requests;
using QuireHut.Demo.Api.Inventory.Responses;
using QuireHut.Demo.Application.Books.Commands;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Api.Inventory.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public BooksController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("")]
    public async Task<ActionResult<CreateBookResponse>> CreateBook(CreateBookRequest book)
    {
        var command = _mapper.Map<CreateBookCommand>(book);
        var result = await _mediator.Send(command);
        
        return result.IsSuccess
            ? CreatedAtAction(nameof(GetBooks),new {bookId=result.Data}, new CreateBookResponse(result.Data))
            : StatusCode(500, result.Error);
    }
    
    [HttpGet("")]
    public async Task<ActionResult<GetBooksResponse>> GetBooks()
    {
        var result = await _mediator.Send(new GetBooksQuery());
        var books = _mapper.Map<List<BookDto>?, List<Book>?>(result.Data?.Books) ?? [];
        var booksResponse = GetBooksResponse.CreateNew(books);
        
        return result.IsSuccess
            ? Ok(booksResponse)
            : StatusCode(500, result.Error);
    }

    [HttpGet("{bookId}")]
    public async Task<ActionResult<GetBookDetailsResponse>> GetBooks(Guid bookId)
    {
        var result = await _mediator.Send(new GetBookDetailsQuery(new BookId(bookId)));
        var bookDetails = _mapper.Map<BookDetails>(result.Data);
        var getBookDetailsResponse = GetBookDetailsResponse.CreateNew(bookDetails);
        
        return result.IsSuccess
            ? Ok(getBookDetailsResponse)
            : StatusCode(500, result.Error);
    }
}