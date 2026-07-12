using LawnGardenManagement.Application.Customers.Common;
using LawnGardenManagement.Application.Customers.CreateCustomer;
using Microsoft.AspNetCore.Mvc;

namespace LawnGardenManagement.Api.Controllers;

[ApiController]
[Route("api/customers")]
public sealed class CustomersController(
    ICreateCustomerService createCustomerService)
    : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(
        typeof(CustomerResponse),
        StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CustomerResponse>> CreateAsync(
        [FromBody] CreateCustomerRequest request,
        CancellationToken cancellationToken)
    {
        CustomerResponse response =
            await createCustomerService.ExecuteAsync(
                request,
                cancellationToken);

        return Created(
            $"/api/customers/{response.Id}",
            response);
    }
}

