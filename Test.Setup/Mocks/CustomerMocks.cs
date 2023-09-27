using ECommerceApplication.Requests;
using ECommerceDomain.DTOs;
using ECommerceDomain.Enums;
using ECommerceInfrastructure.Presentation.Resources;

namespace Test.Setup.Mocks;

public abstract class CustomerMocks
{
    public static readonly CustomerDTO DataToRegister = new()
    {
        Name = "John",
        FirstName = "dev",
        LastName = "woodcutter",
        Email = "john_dev@mail.com",
        Password = BCrypt.Net.BCrypt.HashPassword("test3000"),
    };

    public static readonly CustomerDTO DataToUpdate = new()
    {
        Name = "Gil",
        FirstName = "crazy",
        LastName = "developer",
        Email = "gil_dev@mail.com",
        Password = BCrypt.Net.BCrypt.HashPassword("test5555"),
        Role = nameof(ERoles.customer),
    };

    public static readonly CustomerDTO Customer = new()
    {
        Id = Guid.NewGuid().ToString(),
        Name = "John",
        FirstName = "dev",
        LastName = "woodcutter",
        Email = "john_woodcutter@mail.com",
        Password = BCrypt.Net.BCrypt.HashPassword("test8080"),
        Role = nameof(ERoles.customer),
        CreatedOn = DateTimeOffset.UtcNow,
    };

    public static readonly CreateCustomerRequest CreateRequest = new()
    {
        Name = DataToRegister.Name,
        FirstName = DataToRegister.FirstName,
        LastName = DataToRegister.LastName,
        Email = DataToRegister.Email,
        Password = "test3000",

    };

    public static readonly UpdateCustomerRequest UpdateRequest = new()
    {
        Id = Customer.Id,
        Name = DataToUpdate.Name,
        FirstName = DataToUpdate.FirstName,
        LastName = DataToUpdate.LastName,
        Email = DataToUpdate.Email,
    };

    public static readonly CustomerResource Resource = new(Customer);
}
