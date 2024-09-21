using QuireHut.Demo.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuireHut.Demo.Api.Contracts.Responses;

namespace QuireHut.Demo.Api.Controllers;

[ApiController]
// [Authorize]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("")]
    public async Task<ActionResult<GetBooksResponse>> GetBooks()
    {
        return Ok(LoremIpsum.BooksResponse);
    }

    [HttpGet("{bookId:Guid}")]
    public async Task<IActionResult> GetBooks(Guid bookId)
    {
        return Ok("Books..");
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateBook(CreateBookRequest book)
    {
        var result = await _bookService.CreateBook(book.MapToBookCreationDTO());
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetBooks), new CreateBookResponse(result.Value));
        }

        return StatusCode(500,"");
    }
}
