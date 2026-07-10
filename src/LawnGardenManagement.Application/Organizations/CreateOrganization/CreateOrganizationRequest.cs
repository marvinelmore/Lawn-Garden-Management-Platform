using LawnGardenManagement.Domain.Organizations;

namespace LawnGardenManagement.Application.Organizations.CreateOrganization;

public sealed record CreateOrganizationRequest(
    string Name,
    OrganizationType OrganizationType,
    string? Email,
    string? PhoneNumber);