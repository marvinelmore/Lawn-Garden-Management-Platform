using LawnGardenManagement.Application.Customers.Common;

namespace LawnGardenManagement.Application.Customers.CreateCustomer;

public interface ICreateCustomerService
{
    Task<CustomerResponse> ExecuteAsync(
        CreateCustomerRequest request,
        CancellationToken cancellationToken = default);
}