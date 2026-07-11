using LawnGardenManagement.Application.Organizations.Common;

namespace LawnGardenManagement.Application.Organizations.GetOrganizationById;

public interface IGetOrganizationService
{
    Task<OrganizationResponse?> ExecuteAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}