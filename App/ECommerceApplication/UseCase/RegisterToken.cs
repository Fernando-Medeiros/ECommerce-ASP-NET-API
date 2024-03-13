using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;
using ECommerceDomain.Enums;

namespace ECommerceApplication.UseCase;

public sealed class RegisterToken(
    ICryptService cryptService,
    ITokenService tokenService,
    ICustomerRepository repository,
    IUnitTransaction transaction
    ) : IUseCase<SignInRequest, TokenDTO>
{
    readonly ICryptService _cryptService = cryptService;
    readonly ITokenService _tokenService = tokenService;
    readonly IUnitTransaction _transaction = transaction;
    readonly ICustomerRepository _repository = repository;

    public async Task<TokenDTO> Execute(
        SignInRequest req,
        CancellationToken cancellationToken = default)
    {
        await req.ValidateAsync();


        CustomerDTO? customer = await _repository.Find(new() { Email = req.Email }, cancellationToken)

            ?? throw new CustomerNotFoundException().Target(nameof(RegisterToken));

        if (customer.VerifiedOn == null)

            throw new UnverifiedCustomerException().Target(nameof(RegisterToken));

        if (_cryptService.Verify(req.Password, customer.Password) is false)

            throw new InvalidPasswordException().Target(nameof(RegisterToken));


        _repository.Update(customer);

        await _transaction.Commit(cancellationToken);

        return _tokenService.Generate(customer, ETokenScope.Access);
    }
}
