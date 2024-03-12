using ECommerceApplication.Contract;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;
using ECommerceDomain.Entities;
using ECommerceDomain.Enums;

namespace ECommerceApplication.UseCase;

public sealed class AuthenticateCustomer(
    ITokenService tokenService,
    ICustomerRepository repository,
    IUnitTransaction transaction
    ) : IUseCase<string, TokenDTO>
{
    readonly ITokenService _tokenService = tokenService;
    readonly IUnitTransaction _transaction = transaction;
    readonly ICustomerRepository _repository = repository;

    public async Task<TokenDTO> Execute(
        string id,
        CancellationToken cancellationToken = default)
    {
        CustomerDTO? customer = await _repository.Find(new() { Id = id }, cancellationToken)

            ?? throw new CustomerNotFoundException().Target(nameof(AuthenticateCustomer));


        customer = new Customer(customer)
            .AssignVerified()
            .Mapper();


        _repository.Update(customer);

        await _transaction.Commit(cancellationToken);

        return _tokenService.Generate(customer, ETokenScope.Access);
    }
}
