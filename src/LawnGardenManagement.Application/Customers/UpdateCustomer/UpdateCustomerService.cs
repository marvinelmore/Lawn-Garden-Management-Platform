using LawnGardenManagement.Application.Customers.Common;

namespace LawnGardenManagement.Application.Customers.UpdateCustomer;

public sealed class UpdateCustomerService(
    ICustomerRepository customerRepository)
    : IUpdateCustomerService
{
    public async Task<CustomerResponse?> ExecuteAsync(
        Guid id,
        UpdateCustomerRequest request,
        CancellationToken cancellationToken = default)
    {
        var customer = await customerRepository.GetTrackedByIdAsync(
            id,
            cancellationToken);

        if (customer is null)
        {
            return null;
        }

        if (!string.IsNullOrWhiteSpace(request.Email) &&
            !string.Equals(
                customer.Email,
                request.Email.Trim(),
                StringComparison.OrdinalIgnoreCase))
        {
            bool emailExists = await customerRepository.EmailExistsAsync(
                customer.OrganizationId,
                request.Email,
                cancellationToken);

            if (emailExists)
            {
                throw new InvalidOperationException(
                    $"A customer with email '{request.Email}' already exists in this organization.");
            }
        }

        customer.UpdateDetails(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber);

        await customerRepository.SaveChangesAsync(
            cancellationToken);

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