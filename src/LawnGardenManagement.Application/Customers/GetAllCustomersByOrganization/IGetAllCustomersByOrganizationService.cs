using LawnGardenManagement.Application.Customers.Common;

namespace LawnGardenManagement.Application.Customers.GetAllCustomersByOrganization;

public interface IGetAllCustomersByOrganizationService
{
    Task<IReadOnlyList<CustomerResponse>> ExecuteAsync(
        Guid organizationId,
        CancellationToken cancellationToken = default);
}