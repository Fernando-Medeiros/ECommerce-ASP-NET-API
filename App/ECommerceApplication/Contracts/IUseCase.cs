namespace ECommerceApplication.Contracts;

public interface IUseCase<TRequest, TResponse>
{
    public Task<TResponse> Execute(TRequest data);
}

public interface IUseCase<TRequest>
{
    public Task Execute(TRequest data);
}
