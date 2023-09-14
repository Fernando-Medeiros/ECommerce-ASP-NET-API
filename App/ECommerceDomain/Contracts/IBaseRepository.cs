namespace ECommerceDomain.Contracts;

public interface IBaseRepository<T>
{
    public Task<T?> FindOne(T dto);
    public Task Register(T dto);
    public Task Update(T dto);
    public Task Remove(T dto);
}
