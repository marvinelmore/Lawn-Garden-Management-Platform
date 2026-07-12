using LawnGardenManagement.Domain.Organizations;

namespace LawnGardenManagement.Application.Organizations.UpdateOrganization;

public sealed record UpdateOrganizationRequest(
    string Name,
    string? Email,
    string? PhoneNumber);