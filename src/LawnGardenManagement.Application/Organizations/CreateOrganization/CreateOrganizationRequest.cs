using LawnGardenManagement.Domain.Organizations;

namespace LawnGardenManagement.Application.Organizations.CreateOrganization;

public sealed record CreateOrganizationRequest(
    string Name,
    string? Email,
    string? PhoneNumber);