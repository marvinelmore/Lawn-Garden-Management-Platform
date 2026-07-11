using LawnGardenManagement.Application.Organizations.Common;

namespace LawnGardenManagement.Application.Organizations.UpdateOrganization;

public sealed class UpdateOrganizationService(
    IOrganizationRepository organizationRepository)
    : IUpdateOrganizationService
{
    public async Task<OrganizationResponse?> ExecuteAsync(
        Guid id,
        UpdateOrganizationRequest request,
        CancellationToken cancellationToken = default)
    {
        var organization =
            await organizationRepository.GetTrackedByIdAsync(
                id,
                cancellationToken);

        if (organization is null)
        {
            return null;
        }

        organization.UpdateDetails(
            request.Name,
            request.OrganizationType,
            request.Email,
            request.PhoneNumber);

        await organizationRepository.SaveChangesAsync(
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