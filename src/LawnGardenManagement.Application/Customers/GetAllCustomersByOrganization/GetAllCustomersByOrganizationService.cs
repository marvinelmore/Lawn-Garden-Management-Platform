using LawnGardenManagement.Application.Customers.Common;
using LawnGardenManagement.Application.Organizations;

namespace LawnGardenManagement.Application.Customers.GetAllCustomersByOrganization;

public sealed class GetAllCustomersByOrganizationService(
    ICustomerRepository customerRepository,
    IOrganizationRepository organizationRepository)
    : IGetAllCustomersByOrganizationService
{
    public async Task<IReadOnlyList<CustomerResponse>> ExecuteAsync(
        Guid organizationId,
        CancellationToken cancellationToken = default)
    {
        var organization = await organizationRepository.GetByIdAsync(
            organizationId,
            cancellationToken);

        if (organization is null)
        {
            throw new InvalidOperationException(
                $"Organization '{organizationId}' was not found.");
        }

        var customers =
            await customerRepository.GetByOrganizationIdAsync(
                organizationId,
                cancellationToken);

        return customers
            .Select(customer => new CustomerResponse(
                customer.Id,
                customer.OrganizationId,
                customer.FirstName,
                customer.LastName,
                customer.Email,
                customer.PhoneNumber,
                customer.IsActive,
                customer.CreatedAtUtc,
                customer.UpdatedAtUtc))
            .ToList();
    }
}