using LawnGardenManagement.Application.Organizations.CreateOrganization;
using LawnGardenManagement.Application.Organizations.GetOrganizationById;
using LawnGardenManagement.Application.Organizations.GetAllOrganizations;
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
            IGetOrganizationService,
            GetOrganizationService>();
        
        services.AddScoped<
            IGetAllOrganizationsService,
            GetAllOrganizationsService>();

        return services;
    }
}