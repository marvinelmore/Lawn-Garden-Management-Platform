using LawnGardenManagement.Application.Organizations;
using LawnGardenManagement.Domain.Organizations;
using LawnGardenManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LawnGardenManagement.Infrastructure.Organizations;

public sealed class OrganizationRepository(
    ApplicationDbContext dbContext)
    : IOrganizationRepository
{
    public async Task AddAsync(
        Organization organization,
        CancellationToken cancellationToken = default)
    {
        await dbContext.Organizations.AddAsync(
            organization,
            cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> NameExistsAsync(
        string name,
        CancellationToken cancellationToken = default)
    {
        string normalizedName = name.Trim();

        return await dbContext.Organizations.AnyAsync(
            organization => organization.Name == normalizedName,
            cancellationToken);
    }
}