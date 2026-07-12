using LawnGardenManagement.Application.Organizations.Common;

namespace LawnGardenManagement.Application.Organizations.GetAllOrganizations;

public sealed class GetAllOrganizationsService(
    IOrganizationRepository organizationRepository)
    : IGetAllOrganizationsService
{
    public async Task<IReadOnlyList<OrganizationResponse>> ExecuteAsync(
        CancellationToken cancellationToken = default)
    {
        var organizations = await organizationRepository.GetAllAsync(
            cancellationToken);

        return organizations
            .Select(organization => new OrganizationResponse(
                organization.Id,
                organization.Name,
                organization.Email,
                organization.PhoneNumber,
                organization.IsActive,
                organization.CreatedAtUtc,
                organization.UpdatedAtUtc))
            .ToList();
    }
}