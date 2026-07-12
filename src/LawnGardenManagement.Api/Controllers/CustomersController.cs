using LawnGardenManagement.Application.Customers.Common;
using LawnGardenManagement.Application.Customers.CreateCustomer;
using LawnGardenManagement.Application.Customers.GetCustomerById;
using LawnGardenManagement.Application.Customers.GetAllCustomersByOrganization;

using Microsoft.AspNetCore.Mvc;

namespace LawnGardenManagement.Api.Controllers;

[ApiController]
[Route("api/customers")]
public sealed class CustomersController(
    ICreateCustomerService createCustomerService,
    IGetCustomerByIdService getCustomerByIdService,
    IGetAllCustomersByOrganizationService getAllCustomersByOrganizationService)
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
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(
        typeof(CustomerResponse),
        StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerResponse>> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        CustomerResponse? response =
            await getCustomerByIdService.ExecuteAsync(
                id,
                cancellationToken);

        if (response is null)
        {
            return NotFound();
        }

        return Ok(response);
    }
    
    [HttpGet("/api/organizations/{organizationId:guid}/customers")]
    [ProducesResponseType(
        typeof(IReadOnlyList<CustomerResponse>),
        StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IReadOnlyList<CustomerResponse>>>
        GetAllByOrganizationAsync(
            Guid organizationId,
            CancellationToken cancellationToken)
    {
        IReadOnlyList<CustomerResponse> response =
            await getAllCustomersByOrganizationService.ExecuteAsync(
                organizationId,
                cancellationToken);

        return Ok(response);
    }
}

