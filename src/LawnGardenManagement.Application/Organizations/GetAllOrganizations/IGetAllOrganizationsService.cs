using LawnGardenManagement.Application.Organizations.Common;

namespace LawnGardenManagement.Application.Organizations.GetAllOrganizations;

public interface IGetAllOrganizationsService
{
    Task<IReadOnlyList<OrganizationResponse>> ExecuteAsync(
        CancellationToken cancellationToken = default);
}