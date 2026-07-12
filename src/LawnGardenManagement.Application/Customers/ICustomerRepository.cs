using LawnGardenManagement.Domain.Customers;

namespace LawnGardenManagement.Application.Customers;

public interface ICustomerRepository
{
    Task AddAsync(
        Customer customer,
        CancellationToken cancellationToken = default);

    Task<bool> EmailExistsAsync(
        Guid organizationId,
        string email,
        CancellationToken cancellationToken = default);
    
    Task<Customer?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);
    
    Task<IReadOnlyList<Customer>> GetByOrganizationIdAsync(
        Guid organizationId,
        CancellationToken cancellationToken = default);
    
    Task<Customer?> GetTrackedByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task SaveChangesAsync(
        CancellationToken cancellationToken = default);
}

