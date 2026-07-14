namespace LawnGardenManagement.Application.Properties.CreateProperty;

public sealed record CreatePropertyRequest(
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
    string? AccessNotes);