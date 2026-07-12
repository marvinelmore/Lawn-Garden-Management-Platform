using LawnGardenManagement.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LawnGardenManagement.Infrastructure.Persistence.Configurations;

public sealed class CustomerConfiguration
    : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(customer => customer.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(customer => customer.Email)
            .HasMaxLength(254);

        builder.Property(customer => customer.PhoneNumber)
            .HasMaxLength(30);

        builder.Property(customer => customer.IsActive)
            .IsRequired();

        builder.Property(customer => customer.CreatedAtUtc)
            .IsRequired();

        builder.Property(customer => customer.UpdatedAtUtc);

        builder.HasOne(customer => customer.Organization)
            .WithMany()
            .HasForeignKey(customer => customer.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(customer => customer.OrganizationId);

        builder.HasIndex(customer => new
        {
            customer.OrganizationId,
            customer.Email
        });
    }
}