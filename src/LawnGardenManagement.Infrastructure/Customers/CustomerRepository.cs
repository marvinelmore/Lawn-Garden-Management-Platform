using LawnGardenManagement.Application.Customers;
using LawnGardenManagement.Domain.Customers;
using LawnGardenManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LawnGardenManagement.Infrastructure.Customers;

public sealed class CustomerRepository(
    ApplicationDbContext dbContext)
    : ICustomerRepository
{
    public async Task AddAsync(
        Customer customer,
        CancellationToken cancellationToken = default)
    {
        await dbContext.Customers.AddAsync(
            customer,
            cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> EmailExistsAsync(
        Guid organizationId,
        string email,
        CancellationToken cancellationToken = default)
    {
        string normalizedEmail = email.Trim();

        return await dbContext.Customers.AnyAsync(
            customer =>
                customer.OrganizationId == organizationId &&
                customer.Email == normalizedEmail,
            cancellationToken);
    }
}