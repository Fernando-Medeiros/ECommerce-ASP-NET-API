using ECommerceDomain.DTOs;

namespace ECommerceApplication.Contracts;

public interface ICustomerRepository : IBaseRepository<CustomerDTO>
{
    public Task<CustomerDTO?> FindByEmail(string? email);
}
