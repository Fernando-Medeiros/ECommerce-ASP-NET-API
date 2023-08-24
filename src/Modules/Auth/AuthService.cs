using ECommerce.Exceptions;
using ECommerce.Modules.Customer;
using ECommerce.ModulesHelpers.Crypt;
using ECommerce.ModulesHelpers.Token;

namespace ECommerce.Modules.Auth;

public class AuhService : IAuthService
{
    private readonly ITokenService _tokenService;

    private readonly IAuthRepository _authRepository;

    public AuhService(
        ITokenService tokenService,
        IAuthRepository authRepository)
    {
        _tokenService = tokenService;
        _authRepository = authRepository;
    }

    public async Task<CustomerDTO> FindCustomer(SignInDTO dto)
    {
        CustomerDTO customer = await _authRepository.FindCustomer(dto.Email)
            ?? throw new NotFoundError("Customer Not Found");

        if (customer.VerifiedAt == null)
            throw new UnauthorizedError(
                "Access the link sent to your email to authenticate your account");

        if (CryptPassword.Verify(dto.Password, customer.Password!) is false)
            throw new UnauthorizedError("Email or Password invalid");

        return customer;
    }

    public TokenDTO GenerateAccessToken(CustomerDTO dto)
    {
        return _tokenService.Generate(dto, ETokenScope.Access);
    }
}