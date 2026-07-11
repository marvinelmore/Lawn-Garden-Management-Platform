using LawnGardenManagement.Application.Organizations.Common;

namespace LawnGardenManagement.Application.Organizations.UpdateOrganization;

public interface IUpdateOrganizationService
{
    Task<OrganizationResponse?> ExecuteAsync(
        Guid id,
        UpdateOrganizationRequest request,
        CancellationToken cancellationToken = default);
}