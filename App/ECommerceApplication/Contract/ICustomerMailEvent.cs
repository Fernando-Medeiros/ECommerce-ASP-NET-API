using ECommerceDomain.DTOs;

namespace ECommerceApplication.Contract;

public interface ICustomerMailEvent
{
    public void OnRegisterCustomer(CustomerDTO customer, CancellationToken cancellationToken);

    public void OnRecoverPassword(CustomerDTO customer, CancellationToken cancellationToken);
}