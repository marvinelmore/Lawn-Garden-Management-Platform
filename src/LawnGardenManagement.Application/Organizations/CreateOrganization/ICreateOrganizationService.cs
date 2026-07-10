using LawnGardenManagement.Application.Organizations.Common;

namespace LawnGardenManagement.Application.Organizations.CreateOrganization;

public interface ICreateOrganizationService
{
    Task<OrganizationResponse> ExecuteAsync(
        CreateOrganizationRequest request,
        CancellationToken cancellationToken = default);
}