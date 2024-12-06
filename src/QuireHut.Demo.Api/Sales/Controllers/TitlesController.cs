using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuireHut.Demo.Api.Inventory.Requests;
using QuireHut.Demo.Api.Inventory.Responses;
using QuireHut.Demo.Api.Sales.Responses;
using QuireHut.Demo.Application.Books.Queries;
using QuireHut.Demo.Domain.Books.ValueObjects;

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