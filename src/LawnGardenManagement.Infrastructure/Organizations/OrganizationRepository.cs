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
    
    public async Task<Organization?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Organizations
            .AsNoTracking()
            .SingleOrDefaultAsync(
                organization => organization.Id == id,
                cancellationToken);
    }
    
    public async Task<IReadOnlyList<Organization>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Organizations
            .AsNoTracking()
            .OrderBy(organization => organization.Name)
            .ToListAsync(cancellationToken);
    }
    
    public async Task<Organization?> GetTrackedByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Organizations
            .SingleOrDefaultAsync(
                organization => organization.Id == id,
                cancellationToken);
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}