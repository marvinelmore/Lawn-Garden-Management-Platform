using LawnGardenManagement.Domain.Organizations;

namespace LawnGardenManagement.Application.Organizations.Common;

public sealed record OrganizationResponse(
    Guid Id,
    string Name,
    OrganizationType OrganizationType,
    string? Email,
    string? PhoneNumber,
    bool IsActive,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset? UpdatedAtUtc);