using LawnGardenManagement.Application.Properties.Common;
using LawnGardenManagement.Application.Properties.CreateProperty;
using Microsoft.AspNetCore.Mvc;

namespace LawnGardenManagement.Api.Controllers;

[ApiController]
[Route("api/properties")]
public sealed class PropertiesController(
    ICreatePropertyService createPropertyService)
    : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(
        typeof(PropertyResponse),
        StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PropertyResponse>> CreateAsync(
        [FromBody] CreatePropertyRequest request,
        CancellationToken cancellationToken)
    {
        PropertyResponse response =
            await createPropertyService.ExecuteAsync(
                request,
                cancellationToken);

        return Created(
            $"/api/properties/{response.Id}",
            response);
    }
}
