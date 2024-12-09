using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuireHut.Demo.Api.Models;
using QuireHut.Demo.Api.Sales.Responses;
using QuireHut.Demo.Application.Books.Queries;

namespace QuireHut.Demo.Api.Sales.Controllers;

// [Authorize]
[ApiController]
[Route("api/titles")]
public class TitlesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public TitlesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpGet("")]
    public async Task<ActionResult<GetTitlesResponse>> GetTitles()
    {
        var result = await _mediator.Send(new GetBookTitlesQuery());
        var response = new GetTitlesResponse()
        {
            Titles = _mapper.Map<List<BookTitle>?>(result.Data?.Titles) ?? []
        };
        return result.IsSuccess
            ? Ok(response)
            : StatusCode(500, result.Error);
    }
}