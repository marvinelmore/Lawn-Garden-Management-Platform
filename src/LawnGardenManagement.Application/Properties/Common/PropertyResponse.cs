namespace LawnGardenManagement.Application.Properties.Common;

public sealed record PropertyResponse(
    Guid Id,
    Guid OrganizationId,
    Guid CustomerId,
    string Name,
    string StreetAddress,
    string City,
    string State,
    string PostalCode,
    decimal? LotSizeAcres,
    decimal? Latitude,
    decimal? Longitude,
    string? AccessNotes,
    bool IsActive,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset? UpdatedAtUtc);