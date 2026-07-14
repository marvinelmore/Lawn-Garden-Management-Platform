using LawnGardenManagement.Application.Organizations.CreateOrganization;
using LawnGardenManagement.Application.Organizations.GetOrganizationById;
using LawnGardenManagement.Application.Organizations.GetAllOrganizations;
using LawnGardenManagement.Application.Organizations.UpdateOrganization;
using LawnGardenManagement.Application.Organizations.DeactivateOrganization;
using LawnGardenManagement.Application.Customers.CreateCustomer;
using LawnGardenManagement.Application.Customers.GetCustomerById;
using LawnGardenManagement.Application.Customers.GetAllCustomersByOrganization;
using LawnGardenManagement.Application.Customers.UpdateCustomer;
using LawnGardenManagement.Application.Customers.DeactivateCustomer;
using LawnGardenManagement.Application.Properties.CreateProperty;

using Microsoft.Extensions.DependencyInjection;

namespace LawnGardenManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<
            ICreateOrganizationService,
            CreateOrganizationService>();
        
        services.AddScoped<
            IGetOrganizationByIdService,
            GetOrganizationByIdService>();
        
        services.AddScoped<
            IGetAllOrganizationsService,
            GetAllOrganizationsService>();
        
        services.AddScoped<
            IUpdateOrganizationService,
            UpdateOrganizationService>();
        
        services.AddScoped<
            IDeactivateOrganizationService,
            DeactivateOrganizationService>();
        
        services.AddScoped<
            ICreateCustomerService,
            CreateCustomerService>();
        
        services.AddScoped<
            IGetCustomerByIdService,
            GetCustomerByIdService>();
        
        services.AddScoped<
            IGetAllCustomersByOrganizationService,
            GetAllCustomersByOrganizationService>();
        
        services.AddScoped<
            IUpdateCustomerService,
            UpdateCustomerService>();
        
        services.AddScoped<
            IDeactivateCustomerService,
            DeactivateCustomerService>();
        
        services.AddScoped<
            ICreatePropertyService,
            CreatePropertyService>();

        return services;
    }
}