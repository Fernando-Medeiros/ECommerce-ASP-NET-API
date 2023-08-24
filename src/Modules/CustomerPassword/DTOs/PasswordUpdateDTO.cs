using ECommerce.Modules.Customer;
using ECommerce.ModulesHelpers.Crypt;

namespace ECommerce.Modules.CustomerPassword;

public readonly struct PasswordUpdateDTO
{
    public readonly string Id;
    public readonly string Password;
    public readonly DateTime UpdatedAt;

    public PasswordUpdateDTO(string customerId, string password)
    {
        Id = customerId;
        Password = CryptPassword.Hash(password);
        UpdatedAt = DateTime.UtcNow;
    }

    public static PasswordUpdateDTO ExtractProperties(
        PasswordUpdateRequest req, string customerId)
    {
        return new(customerId, password: req.Password!
        );
    }

    public readonly void UpdateProperties(ref CustomerDTO customer)
    {
        customer.Password = Password;
        customer.UpdatedAt = UpdatedAt;
    }
}
