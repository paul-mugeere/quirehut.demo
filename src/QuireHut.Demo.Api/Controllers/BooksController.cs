using QuireHut.Demo.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuireHut.Demo.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetBooks()
    {
        return Ok("Books..");
    }

    [HttpGet("{bookId:Guid}")]
    public async Task<IActionResult> GetBooks(Guid bookId)
    {
        return Ok("Books..");
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateBook(BookCreateRequest book)
    {
        var result = await _bookService.CreateBook(book.MapToBookCreationDTO());
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetBooks), new BookCreateResponse(result.Value));
        }

        return StatusCode(500,"");
    }
}
