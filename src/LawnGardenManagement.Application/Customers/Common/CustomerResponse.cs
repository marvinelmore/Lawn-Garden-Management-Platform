namespace LawnGardenManagement.Application.Customers.Common;

public sealed record CustomerResponse(
    Guid Id,
    Guid OrganizationId,
    string FirstName,
    string LastName,
    string? Email,
    string? PhoneNumber,
    bool IsActive,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset? UpdatedAtUtc);