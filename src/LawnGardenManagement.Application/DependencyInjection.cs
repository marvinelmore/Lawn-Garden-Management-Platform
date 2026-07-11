using LawnGardenManagement.Application.Organizations.CreateOrganization;
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

        return services;
    }
}