using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuireHut.Demo.Api.Sales.Responses;

namespace QuireHut.Demo.Api.Sales.Controllers;

// [Authorize]
[ApiController]
[Route("api/titles")]
public class TitlesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TitlesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("")]
    public async Task<ActionResult<GetTitlesResponse>> GetTitles()
    {
        return Ok();
    }
}