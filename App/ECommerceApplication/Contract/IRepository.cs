namespace ECommerceApplication.Contract;

public interface IRepository<T>
{
    public Task<T?> Find(T dto, CancellationToken cancellationToken = default);
    public void Register(T dto);
    public void Update(T dto);
    public void Remove(T dto);
}
