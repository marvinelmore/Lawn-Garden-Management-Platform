namespace LawnGardenManagement.Application.Customers.UpdateCustomer;

public sealed record UpdateCustomerRequest(
    string FirstName,
    string LastName,
    string? Email,
    string? PhoneNumber);