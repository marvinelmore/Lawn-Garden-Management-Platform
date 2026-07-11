namespace LawnGardenManagement.Application.Organizations.DeactivateOrganization;

public interface IDeactivateOrganizationService
{
    Task<bool> ExecuteAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}