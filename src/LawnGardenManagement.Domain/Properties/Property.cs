using LawnGardenManagement.Domain.Common;
using LawnGardenManagement.Domain.Customers;
using LawnGardenManagement.Domain.Organizations;

namespace LawnGardenManagement.Domain.Properties;

public sealed class Property : AuditableEntity
{
    private Property()
    {
    }

    public Property(
        Guid organizationId,
        Guid customerId,
        string name,
        string streetAddress,
        string city,
        string state,
        string postalCode,
        decimal? lotSizeAcres = null,
        decimal? latitude = null,
        decimal? longitude = null,
        string? accessNotes = null)
    {
        if (organizationId == Guid.Empty)
        {
            throw new ArgumentException(
                "Organization ID is required.",
                nameof(organizationId));
        }

        if (customerId == Guid.Empty)
        {
            throw new ArgumentException(
                "Customer ID is required.",
                nameof(customerId));
        }

        OrganizationId = organizationId;
        CustomerId = customerId;

        SetName(name);
        SetAddress(streetAddress, city, state, postalCode);

        LotSizeAcres = ValidateLotSize(lotSizeAcres);
        Latitude = ValidateLatitude(latitude);
        Longitude = ValidateLongitude(longitude);
        AccessNotes = NormalizeOptionalValue(accessNotes);

        IsActive = true;
    }

    public Guid OrganizationId { get; private set; }

    public Guid CustomerId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string StreetAddress { get; private set; } = string.Empty;

    public string City { get; private set; } = string.Empty;

    public string State { get; private set; } = string.Empty;

    public string PostalCode { get; private set; } = string.Empty;

    public decimal? LotSizeAcres { get; private set; }

    public decimal? Latitude { get; private set; }

    public decimal? Longitude { get; private set; }

    public string? AccessNotes { get; private set; }

    public bool IsActive { get; private set; }

    public Organization Organization { get; private set; } = null!;

    public Customer Customer { get; private set; } = null!;

    public void UpdateDetails(
        string name,
        string streetAddress,
        string city,
        string state,
        string postalCode,
        decimal? lotSizeAcres,
        decimal? latitude,
        decimal? longitude,
        string? accessNotes)
    {
        SetName(name);
        SetAddress(streetAddress, city, state, postalCode);

        LotSizeAcres = ValidateLotSize(lotSizeAcres);
        Latitude = ValidateLatitude(latitude);
        Longitude = ValidateLongitude(longitude);
        AccessNotes = NormalizeOptionalValue(accessNotes);

        MarkAsUpdated();
    }

    public void Activate()
    {
        if (IsActive)
        {
            return;
        }

        IsActive = true;
        MarkAsUpdated();
    }

    public void Deactivate()
    {
        if (!IsActive)
        {
            return;
        }

        IsActive = false;
        MarkAsUpdated();
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Property name is required.",
                nameof(name));
        }

        Name = name.Trim();
    }

    private void SetAddress(
        string streetAddress,
        string city,
        string state,
        string postalCode)
    {
        if (string.IsNullOrWhiteSpace(streetAddress))
        {
            throw new ArgumentException(
                "Street address is required.",
                nameof(streetAddress));
        }

        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException(
                "City is required.",
                nameof(city));
        }

        if (string.IsNullOrWhiteSpace(state))
        {
            throw new ArgumentException(
                "State is required.",
                nameof(state));
        }

        if (string.IsNullOrWhiteSpace(postalCode))
        {
            throw new ArgumentException(
                "Postal code is required.",
                nameof(postalCode));
        }

        StreetAddress = streetAddress.Trim();
        City = city.Trim();
        State = state.Trim();
        PostalCode = postalCode.Trim();
    }

    private static decimal? ValidateLotSize(decimal? lotSizeAcres)
    {
        if (lotSizeAcres is <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(lotSizeAcres),
                "Lot size must be greater than zero.");
        }

        return lotSizeAcres;
    }

    private static decimal? ValidateLatitude(decimal? latitude)
    {
        if (latitude is < -90 or > 90)
        {
            throw new ArgumentOutOfRangeException(
                nameof(latitude),
                "Latitude must be between -90 and 90.");
        }

        return latitude;
    }

    private static decimal? ValidateLongitude(decimal? longitude)
    {
        if (longitude is < -180 or > 180)
        {
            throw new ArgumentOutOfRangeException(
                nameof(longitude),
                "Longitude must be between -180 and 180.");
        }

        return longitude;
    }

    private static string? NormalizeOptionalValue(string? value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? null
            : value.Trim();
    }
}