using LawnGardenManagement.Application.Organizations.Common;
using LawnGardenManagement.Application.Organizations.CreateOrganization;
using LawnGardenManagement.Application.Organizations.GetOrganizationById;
using LawnGardenManagement.Application.Organizations.GetAllOrganizations;
using LawnGardenManagement.Application.Organizations.UpdateOrganization;

using Microsoft.AspNetCore.Mvc;

namespace LawnGardenManagement.Api.Controllers;

[ApiController]
[Route("api/organizations")]
public sealed class OrganizationsController(
    ICreateOrganizationService createOrganizationService,
    IGetOrganizationByIdService getOrganizationByIdService,
    IGetAllOrganizationsService getAllOrganizationsService,
    IUpdateOrganizationService updateOrganizationService)
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
    
    [HttpGet]
    [ProducesResponseType(
        typeof(IReadOnlyList<OrganizationResponse>),
        StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<OrganizationResponse>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        IReadOnlyList<OrganizationResponse> response =
            await getAllOrganizationsService.ExecuteAsync(cancellationToken);

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(OrganizationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrganizationResponse>> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        OrganizationResponse? response =
            await getOrganizationByIdService.ExecuteAsync(
                id,
                cancellationToken);

        if (response is null)
        {
            return NotFound();
        }

        return Ok(response);
    }
    
    [HttpPut("{id:guid}")]
    [ProducesResponseType(
        typeof(OrganizationResponse),
        StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrganizationResponse>> UpdateAsync(
        Guid id,
        [FromBody] UpdateOrganizationRequest request,
        CancellationToken cancellationToken)
    {
        OrganizationResponse? response =
            await updateOrganizationService.ExecuteAsync(
                id,
                request,
                cancellationToken);

        if (response is null)
        {
            return NotFound();
        }

        return Ok(response);
    }
    
}
