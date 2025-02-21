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
public class TitlesQueryController(ISender sender, IMapper mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<ActionResult<TitlesResponse>> Get()
    {
        var result = await sender.Send(new GetBookTitlesQuery());
        var response = new TitlesResponse()
        {
            Titles = mapper.Map<List<BookTitle>?>(result.Data?.Titles) ?? []
        };
       return result.IsSuccess
         ? Ok(response)
          : StatusCode(500, result.Error);
    }

    [HttpGet("{editionId:guid}/Editions")]
    public async Task<ActionResult<TitleDetailsResponse>> Get(Guid editionId)
    {
        var result = await sender.Send(new GetBookTitleDetailsQuery(editionId));
        var response = new TitleDetailsResponse(mapper.Map<BookTitleDetails>(result.Data));
        return result.IsSuccess
            ? Ok(response)
            : StatusCode(500, result.Error);
    }
}
