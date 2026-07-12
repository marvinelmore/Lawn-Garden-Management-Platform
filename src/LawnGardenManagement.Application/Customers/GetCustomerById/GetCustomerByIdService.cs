using LawnGardenManagement.Application.Customers.Common;

namespace LawnGardenManagement.Application.Customers.GetCustomerById;

public sealed class GetCustomerByIdService(
    ICustomerRepository customerRepository)
    : IGetCustomerByIdService
{
    public async Task<CustomerResponse?> ExecuteAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var customer = await customerRepository.GetByIdAsync(
            id,
            cancellationToken);

        if (customer is null)
        {
            return null;
        }

        return new CustomerResponse(
            customer.Id,
            customer.OrganizationId,
            customer.FirstName,
            customer.LastName,
            customer.Email,
            customer.PhoneNumber,
            customer.IsActive,
            customer.CreatedAtUtc,
            customer.UpdatedAtUtc);
    }
}