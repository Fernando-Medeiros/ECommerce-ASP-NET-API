using ECommerceDomain.DTOs;

namespace ECommerceApplication.Contracts;

public interface ICustomerMailEvent
{
    public void OnRegisterCustomer(CustomerDTO customer, CancellationToken cancellationToken);

    public void OnRecoverPassword(CustomerDTO customer, CancellationToken cancellationToken);
}