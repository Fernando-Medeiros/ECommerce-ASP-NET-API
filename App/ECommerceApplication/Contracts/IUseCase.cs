namespace ECommerceApplication.Contracts;

public interface IUseCase<TRequest, TResponse>
{
    public Task<TResponse> Execute(TRequest data, CancellationToken cancellationToken = default);
}
