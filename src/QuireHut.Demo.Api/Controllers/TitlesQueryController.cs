using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuireHut.Demo.Api.Models;
using QuireHut.Demo.Api.Responses;
using QuireHut.Demo.Application.Books.Queries;

namespace QuireHut.Demo.Api.Controllers;

// [Authorize]
[ApiController]
[Route("api/sales/titles")]
public class TitlesQueryController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<ActionResult<GetTitlesResponse>> Get()
    {
        var result = await mediator.Send(new GetBookTitlesQuery());
        var response = new GetTitlesResponse()
        {
            Titles = mapper.Map<List<BookTitle>?>(result.Data?.Titles) ?? []
        };
       return result.IsSuccess
         ? Ok(response)
          : StatusCode(500, result.Error);
    }

    [HttpGet("{editionId:guid}/Editions")]
    public async Task<ActionResult<GetTitleDetailsResponse>> Get(Guid editionId)
    {
        var result = await mediator.Send(new GetBookTitleDetailsQuery(editionId));
        var response = new GetTitleDetailsResponse(mapper.Map<BookTitleDetails>(result.Data));
        return result.IsSuccess
            ? Ok(response)
            : StatusCode(500, result.Error);
    }
}
