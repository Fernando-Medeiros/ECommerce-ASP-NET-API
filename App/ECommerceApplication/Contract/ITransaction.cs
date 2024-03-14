namespace ECommerceApplication.Contract;

public interface ITransaction
{
    public Task Commit(CancellationToken cancellationToken);
}
