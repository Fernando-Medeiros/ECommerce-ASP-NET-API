namespace ECommerceApplication.Contract;

public interface IUseCase<TRequest, TResponse>
{
    public Task<TResponse> Execute(
        TRequest req,
        CancellationToken cancellationToken = default);
}
