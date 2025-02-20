using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuireHut.Demo.Api.Models;
using QuireHut.Demo.Api.Responses;
using QuireHut.Demo.Application.Books.DTOs.Books;
using QuireHut.Demo.Application.Books.Queries;

namespace QuireHut.Demo.Api.Controllers;

[ApiController]
[Route("api/inventory/books")]
public class BooksQueryController(IMediator mediator, IMapper mapper) : ControllerBase
{
    
    [HttpGet("")]
    public async Task<ActionResult<GetBooksResponse>> Get()
    {
        var result = await mediator.Send(new GetBooksQuery());
        var books = mapper.Map<List<BookQueryResult>?, List<Book>?>(result.Data?.Books) ?? [];
        var booksResponse = GetBooksResponse.CreateNew(books);
        
        return result.IsSuccess
            ? Ok(booksResponse)
            : StatusCode(500, result.Error);
    }

    [HttpGet("{bookId}", Name = "GetBookById")]
    public async Task<ActionResult<GetBookDetailsResponse>> Get(Guid bookId)
    {
        var result = await mediator.Send(new GetBookDetailsQuery(bookId));
        var bookDetails = mapper.Map<BookDetails>(result.Data);
        var getBookDetailsResponse = GetBookDetailsResponse.CreateNew(bookDetails);
        
        return result.IsSuccess
            ? Ok(getBookDetailsResponse)
            : StatusCode(500, result.Error);
    }
}