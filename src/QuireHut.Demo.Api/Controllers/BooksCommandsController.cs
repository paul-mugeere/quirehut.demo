using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuireHut.Demo.Api.Requests;
using QuireHut.Demo.Api.Responses;
using QuireHut.Demo.Application.Books.Commands;

namespace QuireHut.Demo.Api.Controllers;

[ApiController]
[Route("api/inventory/books")]
public class BooksCommandsController(ISender sender, IMapper mapper) : ControllerBase
{
    [HttpPost("")]
    public async Task<ActionResult<BookIdResponse>> Post(PostBookRequest bookRequest)
    {
        var command = mapper.Map<CreateBookCommand>(bookRequest);
        var result = await sender.Send(command);
        
        return result.IsSuccess
            ? CreatedAtRoute(
                routeName:"GetBookById",
                new {bookId=result.Data}, new BookIdResponse(result.Data))
            : StatusCode(500, result.Error);
    }
}