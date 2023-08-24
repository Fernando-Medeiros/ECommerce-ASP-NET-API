using ECommerce.ModulesHelpers.Token;

namespace ECommerce.Modules.Auth;

public interface IAuthService
{
    public Task<TokenDTO> SignIn(SignInDTO dto);

    public Task<TokenDTO> Authenticate(SignInDTO dto);
}
