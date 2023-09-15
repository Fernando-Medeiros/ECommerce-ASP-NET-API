namespace ECommerceApplication.Contracts;

public interface IBaseRepository<T>
{
    public Task<T?> FindOne(T dto);
    public void Register(T dto);
    public void Update(T dto);
    public void Remove(T dto);
}
