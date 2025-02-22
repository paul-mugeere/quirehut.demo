using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuireHut.Demo.Api.Models;
using QuireHut.Demo.Api.Responses;
using QuireHut.Demo.Application.Books.Queries;

namespace QuireHut.Demo.Api.Controllers;

// [Authorize]
[ApiController]
[Route("api/catalog/books")]
public class BooksQueryController(ISender sender, IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<ActionResult<BooksResponse>> Get()
    {
        var result = await sender.Send(new GetBooksQuery());
        var response = new BooksResponse()
        {
            Books = mapper.Map<List<Book>?>(result.Data?.Books) ?? []
        };
       return result.IsSuccess
         ? Ok(response)
          : StatusCode(500, result.Error);
    }

    [HttpGet("{bookId:guid}/editions/{editionId:guid}")]
    public async Task<ActionResult<BookDetailsResponse>> Get(Guid bookId,Guid editionId)
    {
        var result = await sender.Send(new GetBookDetailsQuery(bookId, editionId));
        var response = new BookDetailsResponse(mapper.Map<BookDetails>(result.Data));
        return result.IsSuccess
            ? Ok(response)
            : StatusCode(500, result.Error);
    }
}
