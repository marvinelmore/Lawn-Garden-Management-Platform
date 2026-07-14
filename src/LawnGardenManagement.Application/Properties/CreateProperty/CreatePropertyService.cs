using LawnGardenManagement.Application.Customers;
using LawnGardenManagement.Application.Organizations;
using LawnGardenManagement.Application.Properties.Common;
using LawnGardenManagement.Domain.Properties;

namespace LawnGardenManagement.Application.Properties.CreateProperty;

public sealed class CreatePropertyService(
    IPropertyRepository propertyRepository,
    ICustomerRepository customerRepository,
    IOrganizationRepository organizationRepository)
    : ICreatePropertyService
{
    public async Task<PropertyResponse> ExecuteAsync(
        CreatePropertyRequest request,
        CancellationToken cancellationToken = default)
    {
        var organization = await organizationRepository.GetByIdAsync(
            request.OrganizationId,
            cancellationToken);

        if (organization is null)
        {
            throw new InvalidOperationException(
                $"Organization '{request.OrganizationId}' was not found.");
        }

        if (!organization.IsActive)
        {
            throw new InvalidOperationException(
                "Properties cannot be added to an inactive organization.");
        }

        var customer = await customerRepository.GetByIdAsync(
            request.CustomerId,
            cancellationToken);

        if (customer is null)
        {
            throw new InvalidOperationException(
                $"Customer '{request.CustomerId}' was not found.");
        }

        if (!customer.IsActive)
        {
            throw new InvalidOperationException(
                "Properties cannot be added to an inactive customer.");
        }

        if (customer.OrganizationId != request.OrganizationId)
        {
            throw new InvalidOperationException(
                "The customer does not belong to the supplied organization.");
        }

        bool addressExists = await propertyRepository.AddressExistsAsync(
            request.OrganizationId,
            request.CustomerId,
            request.StreetAddress,
            cancellationToken);

        if (addressExists)
        {
            throw new InvalidOperationException(
                "This customer already has a property with that street address.");
        }

        var property = new Property(
            request.OrganizationId,
            request.CustomerId,
            request.Name,
            request.StreetAddress,
            request.City,
            request.State,
            request.PostalCode,
            request.LotSizeAcres,
            request.Latitude,
            request.Longitude,
            request.AccessNotes);

        await propertyRepository.AddAsync(
            property,
            cancellationToken);

        return new PropertyResponse(
            property.Id,
            property.OrganizationId,
            property.CustomerId,
            property.Name,
            property.StreetAddress,
            property.City,
            property.State,
            property.PostalCode,
            property.LotSizeAcres,
            property.Latitude,
            property.Longitude,
            property.AccessNotes,
            property.IsActive,
            property.CreatedAtUtc,
            property.UpdatedAtUtc);
    }
}