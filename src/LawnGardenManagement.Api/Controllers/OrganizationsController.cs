using LawnGardenManagement.Application.Organizations.Common;
using LawnGardenManagement.Application.Organizations.CreateOrganization;
using LawnGardenManagement.Application.Organizations.GetOrganization;
using Microsoft.AspNetCore.Mvc;

namespace LawnGardenManagement.Api.Controllers;

[ApiController]
[Route("api/organizations")]
public sealed class OrganizationsController(
    ICreateOrganizationService createOrganizationService,
    IGetOrganizationService getOrganizationService)
    : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(OrganizationResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrganizationResponse>> CreateAsync(
        [FromBody] CreateOrganizationRequest request,
        CancellationToken cancellationToken)
    {
        OrganizationResponse response =
            await createOrganizationService.ExecuteAsync(
                request,
                cancellationToken);

        return CreatedAtAction(
            nameof(GetByIdAsync),
            new { id = response.Id },
            response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(OrganizationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrganizationResponse>> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        OrganizationResponse? response =
            await getOrganizationService.ExecuteAsync(
                id,
                cancellationToken);

        if (response is null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}