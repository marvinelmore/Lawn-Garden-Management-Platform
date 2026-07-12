using LawnGardenManagement.Application.Organizations.Common;

namespace LawnGardenManagement.Application.Organizations.GetOrganizationById;

public sealed class GetOrganizationByIdService(
    IOrganizationRepository organizationRepository)
    : IGetOrganizationByIdService
{
    public async Task<OrganizationResponse?> ExecuteAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var organization = await organizationRepository.GetByIdAsync(
            id,
            cancellationToken);

        if (organization is null)
        {
            return null;
        }

        return new OrganizationResponse(
            organization.Id,
            organization.Name,
            organization.Email,
            organization.PhoneNumber,
            organization.IsActive,
            organization.CreatedAtUtc,
            organization.UpdatedAtUtc);
    }
}