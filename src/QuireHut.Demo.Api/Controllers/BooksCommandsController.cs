using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuireHut.Demo.Api.Requests;
using QuireHut.Demo.Api.Responses;
using QuireHut.Demo.Application.Books.Commands;

namespace QuireHut.Demo.Api.Controllers;

[ApiController]
[Route("api/inventory/books")]
public class BooksCommandsController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpPost("")]
    public async Task<ActionResult<CreateBookResponse>> Post(CreateBook book)
    {
        var command = mapper.Map<CreateBookCommand>(book);
        var result = await mediator.Send(command);
        
        return result.IsSuccess
            ? CreatedAtRoute(
                routeName:"GetBookById",
                new {bookId=result.Data}, new CreateBookResponse(result.Data))
            : StatusCode(500, result.Error);
    }
}