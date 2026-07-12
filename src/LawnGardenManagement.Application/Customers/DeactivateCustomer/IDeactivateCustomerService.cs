namespace LawnGardenManagement.Application.Customers.DeactivateCustomer;

public interface IDeactivateCustomerService
{
    Task<bool> ExecuteAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}