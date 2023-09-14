namespace ECommerceDomain.Contracts;

public interface ICustomerRepository<T> : IBaseRepository<T>
{
    public Task<T?> FindByEmail(string? email);
}
