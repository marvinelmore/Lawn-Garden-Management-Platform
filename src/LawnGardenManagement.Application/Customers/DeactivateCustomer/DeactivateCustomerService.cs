namespace LawnGardenManagement.Application.Customers.DeactivateCustomer;

public sealed class DeactivateCustomerService(
    ICustomerRepository customerRepository)
    : IDeactivateCustomerService
{
    public async Task<bool> ExecuteAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var customer = await customerRepository.GetTrackedByIdAsync(
            id,
            cancellationToken);

        if (customer is null)
        {
            return false;
        }

        customer.Deactivate();

        await customerRepository.SaveChangesAsync(
            cancellationToken);

        return true;
    }
}