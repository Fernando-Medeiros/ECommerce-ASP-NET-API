using ECommerceAPI.Resource;
using ECommerceApplication.Request;
using ECommerceDomain.DTO;
using ECommerceDomain.Enums;
using ECommercePersistence.Model;

namespace ECommerceTestSetup.Mocks;

public class CustomerMocks
{
    public readonly string UniqueId;

    public readonly CustomerDTO DataToRegister;

    public readonly CustomerDTO DataToUpdate;

    public readonly CustomerDTO CustomerDTO;

    public readonly Customer CustomerEntity;

    public readonly CustomerRequest CreateRequest;

    public readonly UpdateCustomerRequest UpdateRequest;

    public readonly CustomerResource CustomerResource;


    public CustomerMocks()
    {
        var _re = new
        {
            Name = "John",
            FirstName = "dev",
            LastName = "woodcutter",
            Email = $"john_dev{Guid.NewGuid()}@mail.com",
            Password = BCrypt.Net.BCrypt.HashPassword("test3000"),
        };
        var _up = new
        {
            Name = "Gil",
            FirstName = "crazy",
            LastName = "developer",
            Email = $"gil_dev{Guid.NewGuid()}@mail.com",
            Password = BCrypt.Net.BCrypt.HashPassword("test5555"),
            Role = nameof(ERole.customer),
        };


        UniqueId = Guid.NewGuid().ToString();

        DataToRegister = new()
        {
            Name = _re.Name,
            FirstName = _re.FirstName,
            LastName = _re.LastName,
            Email = _re.Email,
            Password = _re.Password,
        };

        DataToUpdate = new()
        {
            Name = _up.Name,
            FirstName = _up.FirstName,
            LastName = _up.LastName,
            Email = _up.Email,
            Password = _up.Password,
            Role = _up.Role,
        };

        CustomerDTO = new()
        {
            Id = UniqueId,
            Name = _re.Name,
            FirstName = _re.FirstName,
            LastName = _re.LastName,
            Email = _re.Email,
            Password = _re.Password,
            Role = nameof(ERole.customer),
            CreatedOn = DateTimeOffset.UtcNow,
        };

        CustomerEntity = new()
        {
            Id = UniqueId,
            Name = _re.Name,
            FirstName = _re.FirstName,
            LastName = _re.LastName,
            Email = _re.Email,
            Password = _re.Password,
            Role = nameof(ERole.customer),
            CreatedOn = DateTimeOffset.UtcNow,
            UpdatedOn = DateTimeOffset.UtcNow,
            VerifiedOn = DateTimeOffset.UtcNow
        };

        CreateRequest = new()
        {
            Name = _re.Name,
            FirstName = _re.FirstName,
            LastName = _re.LastName,
            Email = _re.Email,
            Password = "test3000",
        };

        UpdateRequest = new()
        {
            Id = UniqueId,
            Name = _up.Name,
            FirstName = _up.FirstName,
            LastName = _up.LastName,
            Email = _up.Email,
        };

        CustomerResource = new CustomerResource(CustomerDTO);
    }
}
