using ECommerce.Modules.Customer;
using ECommerce.ModulesHelpers.Token;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.Auth;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(
        IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("signin")]
    public async Task<ActionResult<TokenResource>> SignIn(
        [FromBody] SignInRequest request)
    {
        CustomerDTO customer = await _authService.FindCustomer(
            dto: SignInDTO.ExtractProperties(request));

        TokenDTO token = _authService.GenerateAccessToken(customer);

        TokenResource resource = new(token);

        return Ok(resource);
    }
}
