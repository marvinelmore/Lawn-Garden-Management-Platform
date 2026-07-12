using LawnGardenManagement.Application.Customers.Common;
using LawnGardenManagement.Application.Organizations;
using LawnGardenManagement.Domain.Customers;

namespace LawnGardenManagement.Application.Customers.CreateCustomer;

public sealed class CreateCustomerService(
    ICustomerRepository customerRepository,
    IOrganizationRepository organizationRepository)
    : ICreateCustomerService
{
    public async Task<CustomerResponse> ExecuteAsync(
        CreateCustomerRequest request,
        CancellationToken cancellationToken = default)
    {
        var organization =
            await organizationRepository.GetByIdAsync(
                request.OrganizationId,
                cancellationToken);

        if (organization is null)
        {
            throw new InvalidOperationException(
                $"Organization '{request.OrganizationId}' was not found.");
        }

        if (!organization.IsActive)
        {
            throw new InvalidOperationException(
                "Customers cannot be added to an inactive organization.");
        }

        if (!string.IsNullOrWhiteSpace(request.Email))
        {
            bool emailExists =
                await customerRepository.EmailExistsAsync(
                    request.OrganizationId,
                    request.Email,
                    cancellationToken);

            if (emailExists)
            {
                throw new InvalidOperationException(
                    $"A customer with email '{request.Email}' already exists in this organization.");
            }
        }

        var customer = new Customer(
            request.OrganizationId,
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber);

        await customerRepository.AddAsync(
            customer,
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