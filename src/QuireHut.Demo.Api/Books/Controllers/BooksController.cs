using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuireHut.Demo.Api.Books.Requests;
using QuireHut.Demo.Api.Books.Responses;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Domain.Books.ValueObjects;

namespace QuireHut.Demo.Api.Books.Controllers;

// [Authorize]
[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("")]
    public async Task<ActionResult<CreateBookResponse>> CreateBook(CreateBookRequest book)
    {
        var result = await _mediator.Send(book.MapToCreateBookCommand());
        return result.IsSuccess
            ? CreatedAtAction(nameof(GetBooks),new {bookId=result.Data}, new CreateBookResponse(result.Data))
            : StatusCode(500, result.Error);
    }
    
    [HttpGet("")]
    public async Task<ActionResult<GetBooksResponse>> GetBooks()
    {
        var result = await _mediator.Send(new GetBooksQuery());
        var booksResponse = new GetBooksResponse
        {
            Books = result.Data?.Books ?? []
        };
        
        return result.IsSuccess
            ? Ok(booksResponse)
            : StatusCode(500, result.Error);
    }

    [HttpGet("{bookId}")]
    public async Task<ActionResult<GetBookDetailsResponse>> GetBooks(Guid bookId, [FromQuery] Guid editionId)
    {
        var result = await _mediator.Send(new GetBookEditionQuery(new BookId(bookId), new EditionId(editionId)));
        return result.IsSuccess
            ? Ok(result.Data)
            : StatusCode(500, result.Error);
    }
}