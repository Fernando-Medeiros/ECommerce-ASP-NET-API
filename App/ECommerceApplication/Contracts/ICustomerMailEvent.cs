using ECommerceDomain.DTOs;

namespace ECommerceApplication.Contracts;

public interface ICustomerMailEvent
{
    public void OnRegisterCustomer(CustomerDTO customer);

    public void OnRecoverPassword(CustomerDTO customer);
}