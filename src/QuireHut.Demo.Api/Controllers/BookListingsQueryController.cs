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
public class BooksListingsQueriesController(ISender sender, IMapper mapper) : ControllerBase
{
    
    [HttpGet("")]
    public async Task<ActionResult<BookListingCollectionResponse>> Get()
    {
        var result = await sender.Send(new GetBookListingsQuery());
        var books = mapper.Map<List<BookListingQueryResult>?, List<BookListing>?>(result.Data?.Books) ?? [];
        var booksResponse = BookListingCollectionResponse.CreateNew(books);
        
        return result.IsSuccess
            ? Ok(booksResponse)
            : StatusCode(500, result.Error);
    }

    [HttpGet("{bookId}", Name = "GetBookById")]
    public async Task<ActionResult<BookListingDetailsResponse>> Get(Guid bookId)
    {
        var result = await sender.Send(new GetBookListingDetailsQuery(bookId));
        var bookDetails = mapper.Map<BookListing>(result.Data);
        var getBookDetailsResponse = BookListingDetailsResponse.CreateNew(bookDetails);
        
        return result.IsSuccess
            ? Ok(getBookDetailsResponse)
            : StatusCode(500, result.Error);
    }
}