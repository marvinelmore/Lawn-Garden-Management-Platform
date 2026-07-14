using LawnGardenManagement.Domain.Properties;

namespace LawnGardenManagement.Application.Properties;

public interface IPropertyRepository
{
    Task AddAsync(
        Property property,
        CancellationToken cancellationToken = default);

    Task<bool> AddressExistsAsync(
        Guid organizationId,
        Guid customerId,
        string streetAddress,
        CancellationToken cancellationToken = default);
}