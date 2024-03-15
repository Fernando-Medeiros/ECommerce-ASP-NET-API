using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;
using ECommerceDomain.Entities;
using ECommerceDomain.Enums;

namespace ECommerceApplication.UseCase.AuthCases;

public sealed class CheckEmail(
    ITokenService tokenService,
    ITransaction transaction,
    ICustomerRepository repository
    ) : IUseCase<IdentityRequest, TokenDTO>
{
    readonly ITokenService _tokenService = tokenService;
    readonly ITransaction _transaction = transaction;
    readonly ICustomerRepository _repository = repository;

    public async Task<TokenDTO> Execute(
        IdentityRequest req,
        CancellationToken cancellationToken = default)
    {
        await req.ValidateAsync();


        CustomerDTO customer = await _repository.Find(new(Id: req.Id), cancellationToken)

            ?? throw new CustomerNotFoundException().Target(nameof(CheckEmail));


        customer = new Customer(customer)
            .AssignVerified()
            .Mapper();


        _repository.Update(customer);

        await _transaction.Commit(cancellationToken);

        return _tokenService.Generate(customer, ETokenScope.Access);
    }
}
