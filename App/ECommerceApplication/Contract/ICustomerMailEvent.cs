using ECommerceDomain.DTO;
using ECommerceDomain.Enums;

namespace ECommerceApplication.Contract;

public interface ICustomerMailEvent
{
    public void Subscribe(
        ETokenScope scope,
        CustomerDTO customer,
        CancellationToken cancellationToken);
}