using LawnGardenManagement.Domain.Organizations;

namespace LawnGardenManagement.Application.Organizations;

public interface IOrganizationRepository
{
    Task AddAsync(
        Organization organization,
        CancellationToken cancellationToken = default);

    Task<bool> NameExistsAsync(
        string name,
        CancellationToken cancellationToken = default);
}