using ECommerceDomain.DTO;

namespace ECommerceApplication.Contract;

public interface ICustomerRepository
{
    public Task<CustomerDTO?> Find(
        CustomerDTO dto,
        CancellationToken cancellationToken = default);
    public void Register(CustomerDTO dto);
    public void Update(CustomerDTO dto);
    public void Remove(CustomerDTO dto);
}
