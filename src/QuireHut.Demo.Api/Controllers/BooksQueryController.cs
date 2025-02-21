using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuireHut.Demo.Api.Models;
using QuireHut.Demo.Api.Responses;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Application.Books.Queries.ReadModels;

namespace QuireHut.Demo.Api.Controllers;

[ApiController]
[Route("api/inventory/books")]
public class BooksQueryController(ISender sender, IMapper mapper) : ControllerBase
{
    
    [HttpGet("")]
    public async Task<ActionResult<BooksCollectionResponse>> Get()
    {
        var result = await sender.Send(new GetBooksQuery());
        var books = mapper.Map<List<BookQueryResult>?, List<Book>?>(result.Data?.Books) ?? [];
        var booksResponse = BooksCollectionResponse.CreateNew(books);
        
        return result.IsSuccess
            ? Ok(booksResponse)
            : StatusCode(500, result.Error);
    }

    [HttpGet("{bookId}", Name = "GetBookById")]
    public async Task<ActionResult<BookDetailsResponse>> Get(Guid bookId)
    {
        var result = await sender.Send(new GetBookDetailsQuery(bookId));
        var bookDetails = mapper.Map<BookDetails>(result.Data);
        var getBookDetailsResponse = BookDetailsResponse.CreateNew(bookDetails);
        
        return result.IsSuccess
            ? Ok(getBookDetailsResponse)
            : StatusCode(500, result.Error);
    }
}