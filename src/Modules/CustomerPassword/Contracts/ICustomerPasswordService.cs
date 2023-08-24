namespace ECommerce.Modules.CustomerPassword;

public interface ICustomerPasswordService
{
    public Task RecoverPassword(PasswordRecoverDTO dto);

    public Task UpdatePassword(PasswordUpdateDTO dto);
}