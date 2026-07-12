namespace LawnGardenManagement.Application.Customers.CreateCustomer;

public sealed record CreateCustomerRequest(
    Guid OrganizationId,
    string FirstName,
    string LastName,
    string? Email,
    string? PhoneNumber);