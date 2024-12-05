using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace QuireHut.Demo.Api.Customers.Controllers;

[Authorize(Policy = "ManageCustomerOrder")]
[Route("api/customers")]
public class CustomerOrdersController : ControllerBase
{
    [HttpGet("{customerId}/orders")]
    public IActionResult Get()
    {
        // Retrieve the authenticated user's information from a data source
        var user = GetAuthenticatedUser();

        return Ok(user);
    }

    private object GetAuthenticatedUser()
    {
        // Dummy implementation for demonstration purposes
        return new
        {
            Name = "John Doe",
            Email = "john.doe@example.com",
            Age = 30
        };
    }

}