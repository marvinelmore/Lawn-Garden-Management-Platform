using LawnGardenManagement.Domain.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LawnGardenManagement.Infrastructure.Persistence.Configurations;

public sealed class OrganizationConfiguration
    : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("Organizations");

        builder.HasKey(organization => organization.Id);

        builder.Property(organization => organization.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(organization => organization.OrganizationType)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(organization => organization.Email)
            .HasMaxLength(254);

        builder.Property(organization => organization.PhoneNumber)
            .HasMaxLength(30);

        builder.Property(organization => organization.IsActive)
            .IsRequired();

        builder.Property(organization => organization.CreatedAtUtc)
            .IsRequired();

        builder.Property(organization => organization.UpdatedAtUtc);

        builder.HasIndex(organization => organization.Name)
            .IsUnique();
    }
}