using LawnGardenManagement.Application.Customers.Common;

namespace LawnGardenManagement.Application.Customers.UpdateCustomer;

public interface IUpdateCustomerService
{
    Task<CustomerResponse?> ExecuteAsync(
        Guid id,
        UpdateCustomerRequest request,
        CancellationToken cancellationToken = default);
}