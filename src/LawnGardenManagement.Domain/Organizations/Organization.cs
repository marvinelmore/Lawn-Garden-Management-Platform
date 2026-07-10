using LawnGardenManagement.Domain.Common;

namespace LawnGardenManagement.Domain.Organizations;

public sealed class Organization : AuditableEntity
{
    private Organization()
    {
    }

    public Organization(
        string name,
        OrganizationType organizationType,
        string? email = null,
        string? phoneNumber = null)
    {
        SetName(name);

        OrganizationType = organizationType;
        Email = NormalizeOptionalValue(email);
        PhoneNumber = NormalizeOptionalValue(phoneNumber);
        IsActive = true;
    }

    public string Name { get; private set; } = string.Empty;

    public OrganizationType OrganizationType { get; private set; }

    public string? Email { get; private set; }

    public string? PhoneNumber { get; private set; }

    public bool IsActive { get; private set; }

    public void UpdateContactInformation(string? email, string? phoneNumber)
    {
        Email = NormalizeOptionalValue(email);
        PhoneNumber = NormalizeOptionalValue(phoneNumber);

        MarkAsUpdated();
    }

    public void Rename(string name)
    {
        SetName(name);
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
                "Organization name is required.",
                nameof(name));
        }

        Name = name.Trim();
    }

    private static string? NormalizeOptionalValue(string? value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? null
            : value.Trim();
    }
}