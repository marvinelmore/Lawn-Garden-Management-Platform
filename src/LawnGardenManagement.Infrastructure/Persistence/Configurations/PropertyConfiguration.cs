using LawnGardenManagement.Domain.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LawnGardenManagement.Infrastructure.Persistence.Configurations;

public sealed class PropertyConfiguration
    : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.ToTable("Properties");

        builder.HasKey(property => property.Id);

        builder.Property(property => property.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(property => property.StreetAddress)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(property => property.City)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(property => property.State)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(property => property.PostalCode)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(property => property.LotSizeAcres)
            .HasPrecision(10, 2);

        builder.Property(property => property.Latitude)
            .HasPrecision(9, 6);

        builder.Property(property => property.Longitude)
            .HasPrecision(9, 6);

        builder.Property(property => property.AccessNotes)
            .HasMaxLength(1000);

        builder.Property(property => property.IsActive)
            .IsRequired();

        builder.Property(property => property.CreatedAtUtc)
            .IsRequired();

        builder.Property(property => property.UpdatedAtUtc);

        builder.HasOne(property => property.Organization)
            .WithMany()
            .HasForeignKey(property => property.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(property => property.Customer)
            .WithMany()
            .HasForeignKey(property => property.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(property => property.OrganizationId);

        builder.HasIndex(property => property.CustomerId);

        builder.HasIndex(property => new
        {
            property.OrganizationId,
            property.CustomerId,
            property.StreetAddress
        });
    }
}