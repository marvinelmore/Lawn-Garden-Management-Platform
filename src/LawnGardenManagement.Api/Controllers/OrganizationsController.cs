using LawnGardenManagement.Application.Organizations.Common;
using LawnGardenManagement.Application.Organizations.CreateOrganization;
using Microsoft.AspNetCore.Mvc;

namespace LawnGardenManagement.Api.Controllers;

[ApiController]
[Route("api/organizations")]
public sealed class OrganizationsController(
    ICreateOrganizationService createOrganizationService)
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

        return Created(
            $"/api/organizations/{response.Id}",
            response);
    }
}