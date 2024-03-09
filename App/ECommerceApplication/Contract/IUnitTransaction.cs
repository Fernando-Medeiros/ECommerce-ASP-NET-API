namespace ECommerceApplication.Contract;

public interface IUnitTransaction
{
    public Task Commit(CancellationToken cancellationToken);
}
