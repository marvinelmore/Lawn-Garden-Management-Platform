using LawnGardenManagement.Application.Customers.Common;

namespace LawnGardenManagement.Application.Customers.GetCustomerById;

public interface IGetCustomerByIdService
{
    Task<CustomerResponse?> ExecuteAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}