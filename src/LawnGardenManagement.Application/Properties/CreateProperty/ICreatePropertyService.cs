using LawnGardenManagement.Application.Properties.Common;

namespace LawnGardenManagement.Application.Properties.CreateProperty;

public interface ICreatePropertyService
{
    Task<PropertyResponse> ExecuteAsync(
        CreatePropertyRequest request,
        CancellationToken cancellationToken = default);
}