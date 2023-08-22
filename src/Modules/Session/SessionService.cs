using ECommerce.Exceptions;
using ECommerce.Modules.Customer;
using ECommerce.ModulesHelpers.Crypt;
using ECommerce.ModulesHelpers.Token;

namespace ECommerce.Modules.Session;

public class SessionService : ISessionService
{
    private readonly ITokenService _tokenService;

    private readonly ISessionRepository _sessionRepository;

    public SessionService(
        ITokenService tokenService,
        ISessionRepository repository)
    {
        _tokenService = tokenService;
        _sessionRepository = repository;
    }

    public async Task<CustomerDTO> FindCustomer(SignInDTO dto)
    {
        CustomerDTO customer = await _sessionRepository.FindCustomer(dto.Email)
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