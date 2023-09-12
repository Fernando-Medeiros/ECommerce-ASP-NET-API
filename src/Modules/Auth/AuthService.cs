using ECommerce.Exceptions;
using ECommerce.Modules.Customer;
using ECommerce.ModulesHelpers.Crypt;
using ECommerce.ModulesHelpers.Token;

namespace ECommerce.Modules.Auth;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;

    private readonly ICustomerRepository _customerRepository;

    public AuthService(
        ITokenService tokenService,
        ICustomerRepository customerRepository)
    {
        _tokenService = tokenService;
        _customerRepository = customerRepository;
    }

    public async Task<TokenDTO> SignIn(SignInDTO dto)
    {
        CustomerDTO customer = await FindCustomer(dto);

        IsVerifiedAt(customer.VerifiedAt);

        IsVerifiedPassword(dto.Password, customer.Password);

        return _tokenService.Generate(customer, ETokenScope.Access);
    }

    public async Task<TokenDTO> Authenticate(SignInDTO dto)
    {
        CustomerDTO customer = await FindCustomer(dto);

        IsVerifiedEmail(dto.Email, customer.Email);

        IsVerifiedPassword(dto.Password, customer.Password);

        customer.VerifiedAt = DateTime.UtcNow;

        await _customerRepository.Update(customer);

        return _tokenService.Generate(customer, ETokenScope.Access);
    }

    #region Private

    private async Task<CustomerDTO> FindCustomer(SignInDTO dto)
    {
        return await _customerRepository.Find(new() { Id = dto.Id, Email = dto.Email })
            ?? throw new NotFoundError("Customer Not Found");
    }

    private static void IsVerifiedAt(DateTime? verifiedAt)
    {
        if (verifiedAt == null)
            throw new UnauthorizedError(
                "Access the link sent to your email to authenticate your account");
    }

    private static void IsVerifiedPassword(string password, string? passwordHash)
    {
        if (CryptPassword.Verify(password, passwordHash!) is false)
            throw new BadRequestError(
                "Email or Password invalid");
    }

    private static void IsVerifiedEmail(string email, string? customerEmail)
    {
        if (email != customerEmail)
            throw new BadRequestError(
                "Email is incompatible");
    }
    #endregion
}