using LawnGardenManagement.Application.Properties;
using LawnGardenManagement.Domain.Properties;
using LawnGardenManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LawnGardenManagement.Infrastructure.Properties;

public sealed class PropertyRepository(
    ApplicationDbContext dbContext)
    : IPropertyRepository
{
    public async Task AddAsync(
        Property property,
        CancellationToken cancellationToken = default)
    {
        await dbContext.Properties.AddAsync(
            property,
            cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> AddressExistsAsync(
        Guid organizationId,
        Guid customerId,
        string streetAddress,
        CancellationToken cancellationToken = default)
    {
        string normalizedStreetAddress = streetAddress.Trim();

        return await dbContext.Properties.AnyAsync(
            property =>
                property.OrganizationId == organizationId &&
                property.CustomerId == customerId &&
                property.StreetAddress == normalizedStreetAddress,
            cancellationToken);
    }
}