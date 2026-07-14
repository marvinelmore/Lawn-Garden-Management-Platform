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

curl -X POST http://localhost:5223/api/properties \
-H "Content-Type: application/json" \
-d '{
"organizationId":"2774850e-4ae2-44bc-8175-2afaa64d7af8",
"customerId":"ded17e84-23d5-41e5-ab8f-74feae1ac36e",
"name":"Home",
"streetAddress":"123 Main Street",
"city":"Walterboro",
"state":"SC",
"postalCode":"29488",
"lotSizeAcres":0.75,
"latitude":32.9052,
"longitude":-80.6668,
"accessNotes":"Enter through the left-side gate."
}'