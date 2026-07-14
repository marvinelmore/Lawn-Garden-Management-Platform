using LawnGardenManagement.Infrastructure.Persistence;
using LawnGardenManagement.Application.Organizations;
using LawnGardenManagement.Infrastructure.Organizations;
using LawnGardenManagement.Application.Customers;
using LawnGardenManagement.Infrastructure.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LawnGardenManagement.Application.Properties;
using LawnGardenManagement.Infrastructure.Properties;

namespace LawnGardenManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' was not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<
            IOrganizationRepository, 
            OrganizationRepository>();
        
        services.AddScoped<
            ICustomerRepository,
            CustomerRepository>();
        
        services.AddScoped<
            IPropertyRepository,
            PropertyRepository>();
        
        return services;
    }
}