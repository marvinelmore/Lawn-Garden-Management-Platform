using LawnGardenManagement.Application.Organizations.Common;
using LawnGardenManagement.Domain.Organizations;

namespace LawnGardenManagement.Application.Organizations.CreateOrganization;

public sealed class CreateOrganizationService(
    IOrganizationRepository organizationRepository)
    : ICreateOrganizationService
{
    public async Task<OrganizationResponse> ExecuteAsync(
        CreateOrganizationRequest request,
        CancellationToken cancellationToken = default)
    {
        bool nameExists = await organizationRepository.NameExistsAsync(
            request.Name,
            cancellationToken);

        if (nameExists)
        {
            throw new InvalidOperationException(
                $"An organization named '{request.Name}' already exists.");
        }

        var organization = new Organization(
            request.Name,
            request.OrganizationType,
            request.Email,
            request.PhoneNumber);

        await organizationRepository.AddAsync(
            organization,
            cancellationToken);

        return new OrganizationResponse(
            organization.Id,
            organization.Name,
            organization.OrganizationType,
            organization.Email,
            organization.PhoneNumber,
            organization.IsActive,
            organization.CreatedAtUtc,
            organization.UpdatedAtUtc);
    }
}