namespace LawnGardenManagement.Application.Organizations.DeactivateOrganization;

public sealed class DeactivateOrganizationService(
    IOrganizationRepository organizationRepository)
    : IDeactivateOrganizationService
{
    public async Task<bool> ExecuteAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var organization =
            await organizationRepository.GetTrackedByIdAsync(
                id,
                cancellationToken);

        if (organization is null)
        {
            return false;
        }

        organization.Deactivate();

        await organizationRepository.SaveChangesAsync(
            cancellationToken);

        return true;
    }
}