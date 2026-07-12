using LawnGardenManagement.Domain.Common;
using LawnGardenManagement.Domain.Organizations;

namespace LawnGardenManagement.Domain.Customers;

public sealed class Customer : AuditableEntity
{
    private Customer()
    {
    }

    public Customer(
        Guid organizationId,
        string firstName,
        string lastName,
        string? email = null,
        string? phoneNumber = null)
    {
        if (organizationId == Guid.Empty)
        {
            throw new ArgumentException(
                "Organization ID is required.",
                nameof(organizationId));
        }

        OrganizationId = organizationId;

        SetName(firstName, lastName);

        Email = NormalizeOptionalValue(email);
        PhoneNumber = NormalizeOptionalValue(phoneNumber);
        IsActive = true;
    }

    public Guid OrganizationId { get; private set; }

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string? Email { get; private set; }

    public string? PhoneNumber { get; private set; }

    public bool IsActive { get; private set; }

    public Organization Organization { get; private set; } = null!;

    public void UpdateDetails(
        string firstName,
        string lastName,
        string? email,
        string? phoneNumber)
    {
        SetName(firstName, lastName);

        Email = NormalizeOptionalValue(email);
        PhoneNumber = NormalizeOptionalValue(phoneNumber);

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

    private void SetName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException(
                "Customer first name is required.",
                nameof(firstName));
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException(
                "Customer last name is required.",
                nameof(lastName));
        }

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
    }

    private static string? NormalizeOptionalValue(string? value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? null
            : value.Trim();
    }
}